     void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            if(e.Mode == PowerModes.Suspend)
            {
                this.GracefullyHandleSleep();
            }
        }
