    public string GetUserAppDataPath()
    {
      string path = string.Empty;
      System.Reflection.Assembly assm;
      try
      {
        assm = System.Reflection.Assembly.GetEntryAssembly();
        Type at = typeof(System.Reflection.AssemblyCompanyAttribute);
        object[] r = assm.GetCustomAttributes(at, false);
        System.Reflection.AssemblyCompanyAttribute ct = ((System.Reflection.AssemblyCompanyAttribute)(r[0]));
        path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        path += @"\" + ct.Company;
        path += @"\" + assm.GetName().Version.ToString();
      }
      catch 
      {        
      }
           
      return path;
    }
