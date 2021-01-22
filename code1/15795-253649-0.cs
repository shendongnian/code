    private static void WriteStartupInfo()
    {
        Trace.TraceInformation(GetStartupInfoString());
    }
    private static String GetStartupInfoString() {
        Settings settings = Settings.Default;
        TimeSpan interval = settings.CleanupInterval;
        TimeSpan span = settings.ExpiryTimeSpan;
        string url = settings.TeamFoundationServerUrl; 
        StringBuilder sb = new StringBuilder();
        sb.Append(String.Format("CleanupInterval:{0}{1}", interval,Environment.NewLine));
        sb.Append(String.Format("ExpiryTimeSpan:{0}{1}", span,Environment.NewLine));
        sb.Append(String.Format("TeamFoundationServerUrl:{0}{1}", url,Environment.NewLine));
        return sb.ToString();
    }
