    string data = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    string name = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
    string path = Path.Combine(data, name);
    
    if (Directory.Exists(path))
    {
      // application has been run
    }
    else
    {
      // create the directory on first run
      DirectoryInfo di = Directory.CreateDirectory(appPath);
    }
