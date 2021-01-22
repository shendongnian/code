    using Microsoft.Win32;  // for registry call.
    private string GetDefaultBrowserPath()
    {
       string key = @"HTTP\shell\open\command";
       using(RegistryKey registrykey = Registry.ClassesRoot.OpenSubKey(key, false))
       {
          return ((string)registrykey.GetValue(null, null)).Split('"')[1];
       }
    }
    private void GoToAnchor(string url)
    {
       System.Diagnostics.Process p = new System.Diagnostics.Process();
       p.StartInfo.FileName = GetDefaultBrowserPath();
       p.StartInfo.Arguments = url;
       p.Start();
    }
    // use:
    GoToAnchor("file:///" + Environment.CurrentDirectory.ToString().Replace("\", "/") + "/site.html#Anchor");
