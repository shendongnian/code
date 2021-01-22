    void DisplayWaveGraph(ZedGraphControl graphControl, double[] waveData)
    {
        var pane = graphControl.GraphPane;
        pane.Chart.Border.IsVisible = false;
        pane.Chart.Fill.IsVisible = false;
        pane.Fill.Color = Color.Black;
        pane.Margin.All = 0;
        pane.Title.IsVisible = false;
        pane.XAxis.IsVisible = false;
        pane.XAxis.Scale.Max = waveData.Length - 1;
        pane.XAxis.Scale.Min = 0;
        pane.YAxis.IsVisible = false;
        pane.YAxis.Scale.Max = 1;
        pane.YAxis.Scale.Min = -1;
        var timeData = Enumerable.Range(0, waveData.Length)
                                 .Select(i => (double) i)
                                 .ToArray();
        pane.AddCurve(null, timeData, waveData, Color.Lime, SymbolType.None);
        graphControl.AxisChange();
    }
