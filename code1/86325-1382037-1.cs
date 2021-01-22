    System.Windows.Shapes.Path bPath = new System.Windows.Shapes.Path();
    bPath.Data = (System.Windows.Media.Geometry)this.FindResource("N44");
    				
    bPath.Width = 20;
    bPath.Height = 80;
    				
    bPath.VerticalAlignment = System.Windows.VerticalAlignment.Top;
    bPath.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
    				
    left = left + 40;
    				
    System.Windows.Thickness thickness = new System.Windows.Thickness(left,100,0,0);
    bPath.Margin = thickness;
    								
    bPath.Fill = System.Windows.Media.Brushes.Black;
    LayoutRoot.Children.Add(bPath);
