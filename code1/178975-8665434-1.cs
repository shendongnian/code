    var employees = new Dictionary<int, string>
    {
        {10,"Employee 1"},{20,"Employee 2"},{30,"Employee 3"}
    };
    
    Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Bar;
    
    foreach (KeyValuePair<int, string> employee in employees)
        Chart1.Series[0].Points.AddXY(employee.Value, employee.Key);
