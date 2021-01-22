    PowerPoint.Application app = new PowerPoint.Application();
    app.Visible = Core.MsoTriState.msoTrue; // Sure, let's watch the magic as it happens.
    PowerPoint.Presentation pres = app.Presentations.Add();
    PowerPoint._Slide objSlide = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutTitleOnly);
    PowerPoint.TextRange textRange = objSlide.Shapes[1].TextFrame.TextRange;
    textRange.Text = "My Chart";
    textRange.Font.Name = "Comic Sans MS";  // Oh yeah I did
    textRange.Font.Size = 24;
    Graph.Chart objChart = (Graph.Chart)objSlide.Shapes.AddOLEObject(150, 150, 480, 320,
        "MSGraph.Chart.8", "", Core.MsoTriState.msoFalse, "", 0, "", 
        Core.MsoTriState.msoFalse).OLEFormat.Object;
    objChart.ChartType = Graph.XlChartType.xl3DPie;
    objChart.Legend.Position = Graph.XlLegendPosition.xlLegendPositionBottom;
    objChart.HasTitle = true;
    objChart.ChartTitle.Text = "Sales for Black Programming & Assoc.";  // I'm a regular comedian.
