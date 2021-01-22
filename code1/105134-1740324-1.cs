    grid1.ColumnDefinitions.Add(new ColumnDefinitions());
    grid1.ColumnDefinitions.Add(new ColumnDefinitions());
    grid1.ColumnDefinitions.Add(new ColumnDefinitions());
    grid1.RowDefinitons.Add(new RowDefinition());
    grid1.RowDefinitons.Add(new RowDefinition());
    imgpanel.SetValue(Grid.RowDefinitionProperty, 1);
    imgpanel.SetValue(Grid.ColumnDefinitionProperty, 2);
    grid1.Children.Add(imgpanel);
