    //Suppose you already have a ChartArea with the series plotted and the left Y Axis
    //Add a fake Area where the only appearent thing is your secondary Y Axis
    ChartArea area1 = chart.ChartAreas.Add("ChartAreaCopy_" + series.Name);
    area1.BackColor = Color.Transparent;
    area1.BorderColor = Color.Transparent;
    area1.Position.FromRectangleF(area.Position.ToRectangleF());
    area1.InnerPlotPosition.FromRectangleF(area.InnerPlotPosition.ToRectangleF());
    area1.AxisX.MajorGrid.Enabled = false;
    area1.AxisX.MajorTickMark.Enabled = false;
    area1.AxisX.LabelStyle.Enabled = false;
    area1.AxisY.MajorGrid.Enabled = false;
    area1.AxisY.MajorTickMark.Enabled = false;
    area1.AxisY.LabelStyle.Enabled = false;
    
    area1.AxisY2.Enabled = AxisEnabled.True;
    area1.AxisY2.LabelStyle.Enabled = true;
    // Create a copy of specified series, and change Y Values to categories
    Series seriesCopy = chart.Series.Add(series.Name + "_Copy");
    seriesCopy.ChartType = series.ChartType;
    foreach(DataPoint point in series.Points)
    {
        double category = getYourItemCategory(point.XValue);
        seriesCopy.Points.AddXY(point.XValue, category);
    }
    
    // Hide copied series
    seriesCopy.IsVisibleInLegend = false;
    seriesCopy.Color = Color.Transparent;
    seriesCopy.BorderColor = Color.Transparent;
    //Drop it in the chart to make the area show (only the AxisY2 should appear)
    seriesCopy.ChartArea = area1.Name;
