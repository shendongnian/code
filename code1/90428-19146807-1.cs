    private void RestartWindowsService(string serviceName)
    {
        ServiceController serviceController = new ServiceController(serviceName);
        try
        {
            if ((serviceController.Status.Equals(ServiceControllerStatus.Running)) || (serviceController.Status.Equals(ServiceControllerStatus.StartPending)))
            {
                serviceController.Stop();
            }
            serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
            serviceController.Start();
            serviceController.WaitForStatus(ServiceControllerStatus.Running);
        }
        catch
        {
            ShowMsg(AppTexts.Information, AppTexts.SystematicError, MessageBox.Icon.WARNING);
        }
    }
