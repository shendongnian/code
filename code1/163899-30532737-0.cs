    static string GetJavaInstallationPath()
    {
      string environmentPath = Environment.GetEnvironmentVariable("JAVA_HOME");
      if (!string.IsNullOrEmpty(environmentPath))
      {
        return environmentPath;
      }
      const string JAVA_KEY = "SOFTWARE\\JavaSoft\\Java Runtime Environment\\";
      var localKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry32);
      using (var rk = localKey.OpenSubKey(JAVA_KEY))
      {
        if (rk != null)
        {
          string currentVersion = rk.GetValue("CurrentVersion").ToString();
          using (var key = rk.OpenSubKey(currentVersion))
          {
            return key.GetValue("JavaHome").ToString();
          }
        }
      }
      localKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
      using (var rk = localKey.OpenSubKey(JAVA_KEY))
      {
        if (rk != null)
        {
          string currentVersion = rk.GetValue("CurrentVersion").ToString();
          using (var key = rk.OpenSubKey(currentVersion))
          {
            return key.GetValue("JavaHome").ToString();
          }
        }
      }
      return null;
    }
