    public void ExecuteAsAdmin(string fileName)
    {
        Process proc = new Process();
        proc.StartInfo.FileName = fileName;
        proc.StartInfo.UseShellExecute = true;
        proc.StartInfo.Verb = "runas";
        proc.Start();
    }
