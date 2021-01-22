    private Version GetRunningVersion()
    {
      try
      {
        return Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
      }
      catch
      {
        return Assembly.GetExecutingAssembly().GetName().Version;
      }
    }
