    var columns = from column in headerColumns.Elements("column")
                  select new {
                      PerformanceId = (int)column.Attribute("performanceId"),
                      Text = (string)column.Attribute("text")
                  };
    Dictionary<int, string> myHeaders = columns.ToDictionary(
        column => column.PerformanceId, column => column.Text);
