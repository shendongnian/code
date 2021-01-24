    public static void RunCommand(string path, string parms, string completion, 
        Action<object, EventArgs, string> exitedCallback)
    {
        Process myProc = new Process();
    
        myProc.StartInfo.FileName = path;
        myProc.StartInfo.Arguments = parms;
        myProc.EnableRaisingEvents = true;
        myProc.StartInfo.UseShellExecute = false;
        myProc.Exited += (o, e) => exitedCallback(o, e, completion);
        myProc.Start();
    }
