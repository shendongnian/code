        Line newLine(double x1, double x2, double y1, double y2, Brush brush)
        {
            Line line = new Line();
            line.X1 = x1;
            line.X2 = x2;
            line.Y1 = y1;
            line.Y2 = y2;
            line.StrokeThickness = 1;
            line.Stroke = brush;
            // https://stackoverflow.com/questions/2879033/how-do-you-draw-a-line-on-a-canvas-in-wpf-that-is-1-pixel-thick
            line.SnapsToDevicePixels = true;
            line.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
            base.Children.Add(line);
            return line;
        }
        internal void ShowVertical(double x)
        {
            Line line = newLine(0, 0, 50, 150, Brushes.Red);
            SetLeft(line, x);
        }
