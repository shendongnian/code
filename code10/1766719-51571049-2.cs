    public static string Execute(string file, params string[] args)
    {
        string argpass = "";
        foreach (string arg in args)
            argpass += "\"" + arg + "\" ";
        
        var info = new ProcessStartInfo();
        info.FileName = file;
        info.Arguments = argpass;
        info.UseShellExecute = false;
        info.RedirectStandardOutput = true;
        var p = Process.Start(info);
        p.WaitForExit();
        return p.StandardOutput.ReadToEnd();
    }
