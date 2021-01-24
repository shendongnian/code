    var stripLine = new System.Windows.Forms.DataVisualization.Charting.StripLine()
    {
        BackColor = Color.Blue,
        IntervalOffset = 4, // This is where the stripline starts
        StripWidth = 2 // And this is how long the interval is
    };
    chart1.ChartAreas[0].AxisX.StripLines.Add(stripLine);
