    var group = new DrawingGroup();
    group.Children.Add(new ImageDrawing(new BitmapImage(new Uri(@"...\Some.jpg", UriKind.Absolute)), new Rect(0, 0, ??, ??)));
    group.Children.Add(new ImageDrawing(new BitmapImage(new Uri(@"...\Some.png", UriKind.Absolute)), new Rect(0, 0, ??, ??)));
    
    MyImage.Source = new DrawingImage(group);
