    Process out = new Process("program1.exe", "-some -options");
    Process in = new Process("program2.exe", "-some -options");
    
    out.UseShellExecute = false;
    
    out.RedirectStandardOutput = true;
    in.RedirectStandardInput = true;
    
    using(StreamReader sr = new StreamReader(out.StandardOutput))
    using(StreamWriter sw = new StreamWriter(in.StandardInput))
    {
      string line;
      while((line = sr.ReadLine()) != null)
      {
        sw.WriteLine(line);
      }
    }
