    var Pairs = File.ReadLines(files)
                    .Select(l => l.SplitExtract("|", 2, 2))
                    .GroupBy(3)
                    .Select(g => g.ToList());
    var ColumnNames = Pairs.First().Select(p => p[0].Trim());
    var dt = new DataTable();
    foreach (var cn in ColumnNames)
        dt.Columns.Add(cn, typeof(string));
    foreach (var r in Pairs)
        dt.Rows.Add(r.Select(p => p[1].Trim()).ToArray());
