    var DataValue = new LiveCharts.Wpf.PieChart
                {
                    DisableAnimations = true,
                    Width = 600,
                    Height = 387,
                    Series = ViewModel.PieCollection
                };
    var viewbox = new Viewbox();
                viewbox.Child = DataValue ;
                viewbox.Measure(DataValue .RenderSize);
                viewbox.Arrange(new Rect(new System.Windows.Point(0, 0), DataValue .RenderSize));
                DataValue .Update(true, true);
                viewbox.UpdateLayout();
    //Save as image method with chart and name of image
    SaveToPng(DataValue, "image.png");
