    string batFileName = path + @"\" + Guid.NewGuid() + ".bat";
    using (StreamWriter batFile = new StreamWriter(batFileName))
    {
        batFile.WriteLine($"YOUR COMMAND");
        batFile.WriteLine($"YOUR COMMAND");
        batFile.WriteLine($"YOUR COMMAND");
    }
    ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe", "/c " + batFileName);
    processStartInfo.UseShellExecute = true;
    processStartInfo.CreateNoWindow = true;
    processStartInfo.WindowStyle = ProcessWindowStyle.Normal;
    Process p = new Process();
    p.StartInfo = processStartInfo;
    p.Start();
    p.WaitForExit();
    File.Delete(batFileName);
