    public static string GetPythonVersion()
        {
          string command = "python --version";
          string output = null;
          using (System.Diagnostics.Process p = new System.Diagnostics.Process())
          {
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = false;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = String.Format(@"/c {0}\{1} ", "C:/Python36/", command);
            p.StartInfo.CreateNoWindow = true;
            if (p.Start())
              output = p.StandardError.ReadToEnd();
          }
         return output;
       }
