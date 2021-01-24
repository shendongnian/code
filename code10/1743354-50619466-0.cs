    Process process = new Process();
    process.StartInfo.FileName = "diskpart.exe";
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.CreateNoWindow = true;
    process.StartInfo.RedirectStandardInput = true;
    process.StartInfo.RedirectStandardOutput = true;
    process.Start();
    process.StandardInput.WriteLine("list volume");
    process.StandardInput.WriteLine("exit");
    string output = process.StandardOutput.ReadToEnd();
    process.WaitForExit();
    
    
    var op = output.Split(new string[] { "DISKPART>" }, 3, StringSplitOptions.RemoveEmptyEntries)[1].Split(new string[] { Environment.NewLine },10, StringSplitOptions.RemoveEmptyEntries);
