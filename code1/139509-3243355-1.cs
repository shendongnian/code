    string name1 = System.Windows.Forms.Application.ExecutablePath;
    string name2 = System.IO.Path.GetFullPath(System.Reflection.Assembly.GetExecutingAssembly().Location
    string name3 = System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location);
    string name4 = Environment.GetCommandLineArgs()[0];
    string name5 = System.IO.Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
    string name6 = System.Reflection.Assembly.GetEntryAssembly().CodeBase;
    string name7 = System.Reflection.Assembly.GetEntryAssembly().FullName;
