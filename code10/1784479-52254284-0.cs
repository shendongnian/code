    System.Windows.Controls.Primitives.Popup popup;
...
    StackPanel sp = new StackPanel();
    sp.Margin = new Thickness(10, 10, 10, 10);
    
    Label l1 = new Label();
    l1.Content = "Test label 1";
    l1.Tag = 1;
    l1.MouseLeftButtonUp += l1_MouseLeftButtonUp;
    
    sp.Children.Add(l1);
    
    Border b = new Border();
    b.BorderBrush = System.Windows.Media.Brushes.Black;
    b.Background = System.Windows.Media.Brushes.White;
    b.BorderThickness = new Thickness(1);
    b.CornerRadius = new CornerRadius(10);
    b.Child = sp;
    
    popup = new System.Windows.Controls.Primitives.Popup();
    popup.Child = b;
    popup.AllowsTransparency = true;
    popup.Placement = System.Windows.Controls.Primitives.PlacementMode.Mouse;
    popup.MouseLeave += popup_MouseLeave;
