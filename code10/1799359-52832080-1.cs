    public void StartService()
    {
        using (ServiceController service = new ServiceController(serviceName))
        {
            try
            {
                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running);
            }
            catch (Exception ex)
            {
                throw new Exception($"Can not Start the Windows Service [{serviceName}]", ex);
            }
        }
    }
    public void StartOrRestart()
        {
            if (IsRunningStatus)
                RestartService();
            else if (IsStoppedStatus)
                StartService();
        }
