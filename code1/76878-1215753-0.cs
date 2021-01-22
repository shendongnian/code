    void DisplayWaveGraph(ZedGraphControl graphControl, double[] waveData)
    {
        var pane = graphControl.GraphPane;
        pane.Title.IsVisible = false;
        var xAxis = pane.XAxis;
        xAxis.Title.IsVisible = false;
        xAxis.Scale.Min = 0;
        xAxis.Scale.Max = waveData.Length - 1;
        var yAxis = pane.YAxis;
        yAxis.Title.IsVisible = false;
        yAxis.Scale.Min = -1;
        yAxis.Scale.Max = 1;
        var timeData = Enumerable.Range(0, waveData.Length)
                                 .Select(i => (double) i)
                                 .ToArray();
        pane.AddCurve(null, timeData, waveData, Color.Red, SymbolType.None);
        graphControl.AxisChange();
    }
