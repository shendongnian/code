    Border myborder = new Border
    {
        BorderBrush = Brushes.DarkGray,
        BorderThickness = new Thickness(1);
    }
    GridKalkAuswahl.Children.Add(myborder);
    Grid.SetRowSpan(myborder, noStaffel.Count);
    Grid.SetColumnSpan(myborder, 4);
    
    Border myborder2 = new Border
    {
        BorderBrush = Brushes.Orange,
        BorderThickness = new Thickness(1),
        Margin = myborder.BorderThickness
    }
    GridKalkAuswahl.Children.Add(myborder2);
    Grid.SetRowSpan(myborder2, noStaffel.Count);
    Grid.SetColumnSpan(myborder2, 4);
