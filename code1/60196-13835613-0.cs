    1. string baseDir =   
        System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
     2. String exePath = System.Environment.GetCommandLineArgs()[0];
     3. string appBaseDir =    System.IO.Path.GetDirectoryName
        (System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
