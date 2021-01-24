    private async Task RunRubyScript(string filePath)
    {
      await Task.Run(() =>
      {
        using (var proc = new Process())
        {
          var startInfo = new ProcessStartInfo(@"ruby");
          startInfo.Arguments = filePath;
          startInfo.UseShellExecute = false;
          startInfo.CreateNoWindow = true;
          proc.StartInfo = startInfo;
          proc.Start();
          proc.WaitForExit();
        }
      });
    }
