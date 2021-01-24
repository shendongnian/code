    static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
    {
        Console.WriteLine(e.Exception.Message);
        System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
        Application.Exit();
    }
