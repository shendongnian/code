    System.Environment.CurrentDirectory
    
    //or
   
    Application.StartupPath
    //or
    System.IO.Path.GetDirectoryName(Application.ExecutablePath);
    //or
    System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
    //or
  
    System.AppDomain.CurrentDomain.BaseDirectory
