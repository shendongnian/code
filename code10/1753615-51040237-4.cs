    for(int r = 0; r < myGrid.RowDefinitions.Count; r++)
    {
        for(int c = 0; c < myGrid.ColumnDefinitions.Count; c++)
        {
            var B = new Border { Margin = new Thickness(5), Background = Brushes.Green };
            B.SetValue(Grid.RowProperty, r);
            B.SetValue(Grid.ColumnProperty, c);
            myGrid.Children.Add(B);
        }
    }
