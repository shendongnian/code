    public void Execute() {
      
      Process p = new Process();
      p.StartInfo.FileName = @"C:\MySQL\MySQL Server 5.0\bin\mysql.exe";
      p.StartInfo.Arguments = String.Format( "-u{0} -p{1}", user, password );
      p.StartInfo.UseShellExecute = false;
      p.StartInfo.RedirectStandardInput = true;
      p.StartInfo.RedirectStandardOutput = true;
      p.StartInfo.RedirectStandardError = true;
      p.Start();
      System.IO.StreamWriter SW = p.StandardInput;
      System.IO.StreamReader SR = p.StandardOutput;
      /* Send data to MySQL and capture results */
      SW.Close();
    }
