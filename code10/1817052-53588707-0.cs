     private bool TimerCallBack()
        {
            if (InPage)
            {
                RefreshSensors(IdCode);
                //MessagingCenter.Unsubscribe<MonitoringView>(this, "OnAppearing");
                return true;
            }
            else
            {
                //MessagingCenter.Unsubscribe<MonitoringView>(this, "OnDisAppearing");
                return false;
            }
        }
