    int marginLeft = 50 + (caPaper.Children.Length * 100);
    
    Ellipse newBall = new Ellipse();
    newBall.Fill = new SolidColorBrush(Colors.Red);
    newBall.Height = 70;
    newBall.Width = 70;
    newBall.Margin = new Thickness(marginLeft, 100, 0, 0);
    caPaper.Children.Add(newBall);
