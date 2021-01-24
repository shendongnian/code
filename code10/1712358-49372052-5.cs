    var lineKeys = new HashSet<int>();
    foreach (var line in File.ReadLines(ofd.FileName))
    {
        int hash = line.ToUpper().GetHashCode();
        if (linesKeys.Add(hash) || analysisDatas.All(analysisData =>!string.Equals(analysisData.Text, line, StringComparison.CurrentCultureIgnoreCase)))
        {
             var item = new AnalysisData { Text = line };
             analysisDatas.Add(item);
        }
    }
