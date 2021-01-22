    string[] schools = { "A", "B", "C" };
    string[] classes = { "cl. 1", "cl. 2", "cl. 3" };
    var pane = zg1.GraphPane;
    Random x = new Random();
    
    // Hide the basic scale, show the second with text labels
    pane.X2Axis.Type = AxisType.Text;
    pane.X2Axis.IsVisible = true;
    pane.Y2Axis.Type = AxisType.Text;
    pane.Y2Axis.IsVisible = true;
    pane.XAxis.Scale.IsVisible = false;
    pane.YAxis.Scale.IsVisible = false;
    pane.X2Axis.Scale.TextLabels = schools;
    pane.Y2Axis.Scale.TextLabels = classes;
    // Main problem - synchronize the scales correctly            
    pane.XAxis.Scale.Min = -0.5;
    pane.XAxis.Scale.Max = schools.Count() - 0.5;
    pane.YAxis.Scale.Min = -0.5;
    pane.YAxis.Scale.Max = classes.Count() - 0.5;
    pane.YAxis.MajorGrid.IsZeroLine = false;
    // generate some fake data
    PointPairList list = new PointPairList();
       for(int i=0;i<schools.Count();i++)
          for (int j = 0; j < classes.Count(); j++)
          {
              list.Add(new PointPair(i, j, x.Next(30)));
          }
       var pointsCurve = pane.AddCurve("", list, Color.Transparent);
       pointsCurve.Line.IsVisible = false;
       // Create your own scale of colors.
       pointsCurve.Symbol.Fill = new Fill(new Color[] { Color.Blue, Color.Green, Color.Red });
       pointsCurve.Symbol.Fill.Type = FillType.GradientByZ;
       pointsCurve.Symbol.Fill.RangeMin = 0;
       pointsCurve.Symbol.Fill.RangeMax = 30;
       pointsCurve.Symbol.Type = SymbolType.Circle;
                pane.AxisChange();
                zg1.Refresh();
