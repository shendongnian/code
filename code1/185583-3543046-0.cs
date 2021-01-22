            var t = new TextBlock();
            t.Inlines.Add(new Line { X1 = 0, Y1 = 0, X2 = 100, Y2 = 0, Stroke = new SolidColorBrush(Colors.Black), StrokeThickness = 4.0 });
            t.Inlines.Add("Hello there!");
            t.Inlines.Add(new Line { X1 = 0, Y1 = 0, X2 = 100, Y2 = 0, Stroke =  new SolidColorBrush(Colors.Black),StrokeThickness = 4.0});
            LayoutRoot.Children.Add(t);
