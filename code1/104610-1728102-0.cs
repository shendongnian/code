    void someMethod()
    {
        //...possibly more code here
        Process process = new Process();
        process.StartInfo = new ProcessStartInfo("app.exe");
        process.StartInfo.WorkingDirectory = "";
        process.StartInfo.Arguments = "some arguments";
        process.Exited += new EventHandler(ProcessExited);
        process.Start();
    }
    
    void ProcessExited(object sender, System.EventArgs e)
    {
      //Handle process exit here
    }
