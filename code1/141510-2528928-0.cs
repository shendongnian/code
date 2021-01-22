    Canvas musicPlayerCanvas = new Canvas();
    musicPlayerCanvas.Background = new SolidColorBrush(Colors.Purple);
            
    Border border = new Border();
    border.BorderBrush = new SolidColorBrush(Colors.Black);
    border.BorderThickness = new Thickness(5);
    border.Height = 80;
    border.Width = 1018;
    border.Child = musicPlayerCanvas;
    LayoutRoot.Children.Add(border);
