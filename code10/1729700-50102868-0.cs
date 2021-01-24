            Line myLine = new Line();
            myLine.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            Grid.SetRowSpan(myLine, n); // Here you are setting RowSpan. n-number of rows to span
            Grid.SetColumnSpan(myLine, n); // Here you are setting ColumnSpan. n-number of columns to span
            myLine.X1 = 1;
            myLine.Y1 = 1;
            myLine.X2 = 500;
            myLine.Y2 = 50;
            // myLine.HorizontalAlignment = HorizontalAlignment.Left;
            // myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = 2;
            area.Children.Add(myLine);
