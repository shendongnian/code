    static void CountLines(string path,sting outfile)
    {
       var count = File.ReadLines(path).Count();
       File.WriteAllText(outfile, $"AFP|QTY{Environment.NewLine}DDD|{count}");
    }
