    private Version GetRunningVersion()
    {
      try
      {
        return System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
      }
      catch
      {
        return Assembly.GetExecutingAssembly().GetName().Version;
      }
    }
