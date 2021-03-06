﻿using CheckDeviceArgo.BL;
using System;
using System.Threading;


namespace CheckDeviceArgo
{
    public class MainPresenter
    {
        private readonly IMainForm _view;
        private readonly IDataTransfer _dataTransfer;
        private readonly IMessageServis _message;



        public MainPresenter(IMainForm view, IDataTransfer dataTransfer, IMessageServis message)
        {
            _view = view; _dataTransfer = dataTransfer; _message= message;
            _view.StartTest += _view_StartTest;

        }

        void _view_StartTest(object sender, EventArgs e)
        {
            if (_view.Port1Appoindet == null | _view.Port2Appointed == null
                | (_view.Port1Appoindet == _view.Port2Appointed))
            {
                //_message.ShowExclamation("Не выполнены условия для запуска теста. Например:не выбран один из портов.");
                Start();
            }
            else Start();
        }

        private void Start()
        {
            //_message.ShowMessage("Начинаем тест");
            int i=1; int j=10;
            _view.PrgsBarTestInit(j, 1, true);
            
            do
            {
                _view.PrgsBarTestProgress();
                Thread.Sleep(10);
                i++;
            } while (i < j);

            _view.ArrowPicture(Constans.ArrowsPicture.LeftVisible);
            Thread.Sleep(5000);
            _view.ArrowPicture(Constans.ArrowsPicture.RightVisible);
            Thread.Sleep(5000);
            _view.ArrowPicture(Constans.ArrowsPicture.NoVisible);
        }


    }

}
