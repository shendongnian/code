   public void RunScript(string script, string arguments, out string errorMessage)
   {
      errorMessage = string.empty;
      using (Process process = new Process())
      {
          process.OutputDataReceived += process_OutputDataReceived;
          ProcessStartInfo info = new ProcessStartInfo(script);
          info.Arguments = String.Join(" ", arguments);
          info.UseShellExecute = false;
          info.RedirectStandardError = true;
          info.RedirectStandardOutput = true;
          info.WindowStyle = ProcessWindowStyle.Hidden;
          process.StartInfo = info;
          process.EnableRaisingEvents = true;
          process.Start();
          process.BeginOutputReadLine();
          process.WaitForExit();
          errorMessage = process.StandardError.ReadToEnd();
     }
  }
  private void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
  {
     using (AutoResetEvent errorWaitHandle = new AutoResetEvent(false))
     {
         if (!string.IsNullOrEmpty(e.Data))
         {
              // Write the output somewhere
          }
      }
  }
</pre>
