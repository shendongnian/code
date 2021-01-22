    private void CreateColumnDefinitions(Grid grid)
            {
                grid.ColumnDefinitions.Add(
                    new ColumnDefinition() { Width = new GridLength(10, GridUnitType.Star) });
    
                grid.ColumnDefinitions.Add(
                    new ColumnDefinition() { Width = new GridLength(5, GridUnitType.Star) });
    
                grid.ColumnDefinitions.Add(
                    new ColumnDefinition() { Width = new GridLength(5, GridUnitType.Star) });
            }
