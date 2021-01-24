    public DataTable GetData(List<Article> list)
    {
        var dt = new DataTable();
        dt.Columns.Add("Title", typeof(string));
        dt.Columns.Add("Date", typeof(DateTime));
        var max = list.Max(x => x.Reviews.Count());
        for (int i = 0; i < max; i++)
            dt.Columns.Add($"Reviewer {i + 1} Points", typeof(int));
        foreach (var item in list)
            dt.Rows.Add(new object[] { item.Title, item.Date }.Concat(
                item.Reviews.Select(x => x.Points).Cast<object>()).ToArray());
        return dt;
    }
