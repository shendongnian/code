    var lineKeys = new HashSet<string>();
    foreach (var line in File.ReadLines(ofd.FileName))
    {
        if (linesKeys.Add(line.ToUpper()))
        {
             var item = new AnalysisData { Text = line };
             analysisDatas.Add(item);
        }
    }
