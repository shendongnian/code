    var lineKeys = new HashSet<int>();
    foreach (var line in File.ReadLines(ofd.FileName))
    {
        int hash = line.ToUpper().GetHashCode();
        if (linesKeys.Add(hash))
        {
             var item = new AnalysisData { Text = line };
             analysisDatas.Add(item);
        }
    }
