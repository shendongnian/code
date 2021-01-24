    IEnumerable<string> files = Directory.EnumerateFiles(myPath, searchPattern: "*.xlsx", searchOption: SearchOption.AllDirectories).Select(x => Path.GetFileName(x));
    Regex reg = new Regex(".*_(?<dmy>Day|Month|Year)\\.xlsx");
    var groups = files.GroupBy(x => reg.Match(x).Groups["dmy"].Value);
    StringBuilder builder = new StringBuilder();
    foreach (var g in groups.OrderBy(x => x.Key == "Year" ? 0 : x.Key == "Day" ? 1 : 2))
    {
        builder.AppendLine();
        foreach(var f in g.OrderByDescending(x => x))
        {
            builder.AppendLine(f);
        }
    }
