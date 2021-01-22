    Process process = new Process();
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.RedirectStandardOutput = true;
    process.StartInfo.FileName = "cmd.exe";
    process.StartInfo.Arguments = "/c net use";
    process.Start();
    string output = process.StandardOutput.ReadToEnd();
    process.WaitForExit();
    
    
    var line = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                        .Where(x => x.Contains("U:")).FirstOrDefault();
    if (!string.IsNullOrEmpty(line))
    {
        var host = line.Substring(line.IndexOf("\\"), line.Substring(line.IndexOf("\\")).IndexOf(" ")).Split(new[] { '\\' }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
    }
