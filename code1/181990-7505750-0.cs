    chrtMain.Series[0].YAxisType = AxisType.Primary;
    chrtMain.Series[1].YAxisType = AxisType.Secondary;
    
    chrtMain.ChartAreas[0].AxisY2.LineColor = Color.Transparent;
    chrtMain.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
    chrtMain.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
    chrtMain.ChartAreas[0].AxisY2.IsStartedFromZero = chrtMain.ChartAreas[0].AxisY.IsStartedFromZero;
