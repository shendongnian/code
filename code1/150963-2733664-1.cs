    var columns = from panel in doc.Elements("PerformancePanel")
                  from headers in panel.Elements("HeaderColumns")
                  from column in headers.Elements("column")
                  select new {
                      PerformanceId = (int)column.Attribute("performanceId"),
                      Text = (string)column.Attribute("text")
                  };
    Dictionary<int, string> myHeaders = columns.ToDictionary(
        column => column.PerformanceId, column => column.Text);
