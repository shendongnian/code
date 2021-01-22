    public static void WriteAdjustedPaths(string inpath, string outpath)
    {
      using (var w = new StreamWriter(outpath))
      {
        foreach (var p in AdjustedPaths(inpath))
          w.WriteLine("{0}", p);
      }
    }
