    chart3.Series.Clear();
    Series s1 = chart3.Series.Add("S1");
    s1.ChartType = SeriesChartType.StackedColumn;
    Series s2 = chart3.Series.Add("S2");
    s2.ChartType = SeriesChartType.StackedColumn;
    Series s0 = chart3.Series.Add("S0");
    s0.ChartType = SeriesChartType.StackedColumn;
    s0.Color = Color.LightGray;
    s0.IsVisibleInLegend = false;
    s0["StackedGroupName"] = "Group1";
    s1["StackedGroupName"] = "Group1";
    s2["StackedGroupName"] = "Group2";
    for (int j = 0; j < data.Columns.Count; j++)
    {
        for (int i = 0; i < data.Rows.Count; i++)
        {
            double vy = Convert.ToDouble(data.Rows[i][j].ToString());
            chart3.Series[i].Points.AddXY(j, vy);
            if (i==0)  s0.Points.AddXY(j, 800 - vy);
        }
    }
    List<string> mn = new List<string>() { "J", "F", "M", "A" };
    for (int i = 0; i < s0.Points.Count; i++)
    {
        s0.Points[i].AxisLabel = mn[i];
    }
