    private FrameworkElementFactory AddPointsToSeries(KeyValuePair<ChartSerie, List<ChartDataPoint>> chartSeries, int colorPaletteIndex)
        {
            var   seriesPredefinedColor = this.ChartBase.Palette.GlobalEntries[colorPaletteIndex].Fill;
            Brush brush                 = chartSeries.Key.ColorHex == null ? (seriesPredefinedColor) : ColorService.HexToBrush(chartSeries.Key.ColorHex);
            Brush mouseOnEnterColor     = new SolidColorBrush(ColorService.ChangeColorLightness(ColorService.BrushToColor(brush), 0.8));
            double ellipseMouseOverStrokeThickness = 2;
            double ellipseMouseOverHeightWidth     = 13;
            double ellipseStrokeThickness          = 1;
            double ellipseHeightWidth              = 9;
            FrameworkElementFactory frameworkElement = new FrameworkElementFactory(typeof(Ellipse));
            frameworkElement.SetValue(Ellipse.FillProperty, brush);
            frameworkElement.SetValue(Ellipse.MarginProperty, new Thickness(-4.5));
            frameworkElement.SetValue(Ellipse.HeightProperty, ellipseHeightWidth);
            frameworkElement.SetValue(Ellipse.WidthProperty, ellipseHeightWidth);
            frameworkElement.SetValue(Ellipse.StrokeProperty, new SolidColorBrush(Colors.White));
            frameworkElement.SetValue(Ellipse.StrokeThicknessProperty, ellipseStrokeThickness);
            frameworkElement.AddHandler(Ellipse.MouseEnterEvent, new MouseEventHandler((sender, args) =>
                                                                                       {
                                                                                           Ellipse ellipse = (Ellipse)sender;
                                                                                           ellipse.Fill            = new SolidColorBrush(Colors.White);
                                                                                           ellipse.Stroke          = mouseOnEnterColor;
                                                                                           ellipse.StrokeThickness = ellipseMouseOverStrokeThickness;
                                                                                           ellipse.Width           = ellipseMouseOverHeightWidth;
                                                                                           ellipse.Height          = ellipseMouseOverHeightWidth;
                                                                                       }));
            frameworkElement.AddHandler(Ellipse.MouseLeaveEvent, new MouseEventHandler((sender, args) =>
                                                                                       {
                                                                                           Ellipse ellipse = (Ellipse)sender;
                                                                                           ellipse.Stroke          = new SolidColorBrush(Colors.White);
                                                                                           ellipse.Fill            = brush;
                                                                                           ellipse.StrokeThickness = ellipseStrokeThickness;
                                                                                           ellipse.Height          = ellipseHeightWidth;
                                                                                           ellipse.Width           = ellipseHeightWidth;
                                                                                       }));
            FrameworkElementFactory stackPanelFactory = new FrameworkElementFactory(typeof(Grid));
            stackPanelFactory.SetValue(Grid.HeightProperty, ellipseMouseOverHeightWidth + ellipseMouseOverStrokeThickness);
            stackPanelFactory.SetValue(Grid.WidthProperty, ellipseMouseOverHeightWidth  + ellipseMouseOverStrokeThickness);
            stackPanelFactory.AppendChild(frameworkElement);
            return stackPanelFactory;
        }
