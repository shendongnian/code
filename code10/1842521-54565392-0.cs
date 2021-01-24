    // To get application's name:
    public string ApplicationName => SystemInformation.ApplicationName;
    // To get application's version:
    public string ApplicationVersion => $"{SystemInformation.ApplicationVersion.Major}.{SystemInformation.ApplicationVersion.Minor}.{SystemInformation.ApplicationVersion.Build}.{SystemInformation.ApplicationVersion.Revision}";
        
