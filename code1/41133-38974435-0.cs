    private static string Execute(string credentials, string scriptDir, string scriptFilename)
    { 
      Process process = new Process();
      process.StartInfo.UseShellExecute = false;
      process.StartInfo.WorkingDirectory = scriptDir;
      process.StartInfo.RedirectStandardOutput = true;
      process.StartInfo.FileName = "sqlplus";
      process.StartInfo.Arguments = string.Format("{0} @{1}", credentials, scriptFilename);
      process.StartInfo.CreateNoWindow = true;
      process.Start();
      string output = process.StandardOutput.ReadToEnd();
      process.WaitForExit();
      return output;
    }
