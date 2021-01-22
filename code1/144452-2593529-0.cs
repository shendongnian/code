    private startApp()
    {
        string command = " -h"; //common help flag for console apps
        System.Diagnostics.Process pRun;
        pRun = new System.Diagnostics.Process();
        pRun.EnableRaisingEvents = true;
        pRun.Exited += new EventHandler(pRun_Exited);
        pRun.StartInfo.FileName = "app.exe";
        pRun.StartInfo.Arguments = command;
        pRun.StartInfo.WindowStyle =  System.Diagnostics.ProcessWindowStyle.Normal
    
        pRun.Start();
        pRun.WaitForExit();
    }
    private void  pRun_Exited(object sender, EventArgs e)
    {
        //Do Something Here
    }
