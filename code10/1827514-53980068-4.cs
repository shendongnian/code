    public delegate string CompletionFunc(object o, EventArgs e, string s);
    public static void RunCommand(string path, string parms, string completion, CompletionFunc completionFunc)
    {
        string result = string.Empty;
        Process myProc = new Process();
        myProc.StartInfo.FileName = path;
        myProc.StartInfo.Arguments = parms;
        myProc.EnableRaisingEvents = true;
        myProc.StartInfo.UseShellExecute = false;
        myProc.Exited += (obj, evt) => {
            result = completionFunc(obj, evt, completion);
            Console.WriteLine($"{result} ExitCode: {myProc.ExitCode})");
            if (myProc != null) myProc.Dispose();
        };
        myProc.Start();
    }
