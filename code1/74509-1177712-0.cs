    public static string Md5SumByProcess(string file) {
        var p = new Process ();
        p.StartInfo.FileName = "md5sum.exe";
        p.StartInfo.Arguments = file;            
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardOutput = true;
        p.Start();
        p.WaitForExit();           
        string output = p.StandardOutput.ReadToEnd();
        return output.Split(' ')[0].Substring(1).ToUpper ();
    }
