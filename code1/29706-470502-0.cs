        string fullapppath = Assembly.GetExecutingAssembly().Location;
        string apppath = System.IO.Path.GetDirectoryName(fullapppath);
        string path1 = System.IO.Path.Combine(apppath, @"../Tools/RunHidden");
        string path2 = System.IO.Path.Combine(apppath, @"../My-Bridge.bat");
    
        bridge_process = System.Diagnostics.Process.Start(path1, path2);
