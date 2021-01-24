    private void chart1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        var hit = chart1.HitTest(e.X, e.Y, ChartElementType.DataPoint);
        if (hit.PointIndex >= 0)
        {
            DataPoint dp = hit.Series.Points[hit.PointIndex];
            Console.WriteLine(dp.YValues[0]);
        }
    }
