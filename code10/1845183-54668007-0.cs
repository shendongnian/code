        var model = new PlotModel("LineSeries") { LegendSymbolLength = 24 };
        var s1 = new LineSeries("Series 1")
        {
            Color = OxyColors.SkyBlue,
            MarkerType = MarkerType.Circle,
            MarkerSize = 6,
            MarkerStroke = OxyColors.White,
            MarkerFill = OxyColors.SkyBlue,
            MarkerStrokeThickness = 1.5
        };
        s1.Points.Add(new DataPoint(0, 10));
        s1.Points.Add(new DataPoint(10, 40));
        s1.Points.Add(new DataPoint(40, 20));
        s1.Points.Add(new DataPoint(60, 30));
        model.Series.Add(s1);
