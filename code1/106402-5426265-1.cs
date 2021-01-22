    private bool InitMsdtc()
    {
        System.ServiceProcess.ServiceController control = new System.ServiceProcess.ServiceController("MSDTC");
        if (control.Status == System.ServiceProcess.ServiceControllerStatus.Stopped)
            control.Start();
        else if (control.Status == System.ServiceProcess.ServiceControllerStatus.Paused)
            control.Continue();
        return true;
    }
