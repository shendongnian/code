    string name1 = System.Windows.Forms.Application.ExecutablePath;
    string name2 = System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location);
    string name3 = Environment.GetCommandLineArgs()[0];
    string name4 = System.IO.Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
    string name5 = System.Reflection.Assembly.GetEntryAssembly().CodeBase;
    string name6 = System.Reflection.Assembly.GetEntryAssembly().FullName;
