    public static void WriteAdjustedPaths(string inpath, string outpath)
    {
      using (var w = new StreamWriter(outpath))
      {
        var r = new StreamReader(inpath);
        string line;
        while ((line = r.ReadLine()) != null)
          w.WriteLine("{0}", AdjustPath(inpath, line));
      }
    }
