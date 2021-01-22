    using(StreamReader sr = new StreamReader(myProcess.StandardOutput))
    {
      string line;
      while((line = sr.ReadLine()) != null)
      {
        // do something with line
      }
    }
