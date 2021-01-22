    Grid grid = new Grid();
    
    // Set the column and row definitions
    grid.ColumnDefinitions.Add(new ColumnDefinition() {
         Width = new GridLength(1, GridUnitType.Auto) });
    grid.ColumnDefinitions.Add(new ColumnDefinition() {
         Width = new GridLength(1, GridUnitType.Star) });
    grid.RowDefinitions.Add(new RowDefinition() {
         Height = new GridLength(1, GridUnitType.Auto) });
    grid.RowDefinitions.Add(new RowDefinition() {
         Height = new GridLength(1, GridUnitType.Auto) });
    
    // Row 0
    TextBlock tbFirstNameLabel = new TextBlock() { Text = "First Name: "};
    TextBlock tbFirstName = new TextBlock() { Text = "John"};
    
    grid.Children.Add(tbFirstNameLabel ); // Add to the grid
    Grid.SetRow(tbFirstNameLabel , 0); // Specify row for previous grid addition
    Grid.SetColumn(tbFirstNameLabel , 0); // Specity column for previous grid addition
    
    grid.Children.Add(tbFirstName ); // Add to the grid
    Grid.SetRow(tbFirstName , 0);  // Specify row for previous grid addition
    Grid.SetColumn(tbFirstName , 1); // Specity column for previous grid addition
    
    // Row 1
    TextBlock tbLastNameLabel = new TextBlock() { Text = "Last Name: "};
    TextBlock tbLastName = new TextBlock() { Text = "Smith"};
    
    grid.Children.Add(tbLastNameLabel ); // Add to the grid
    Grid.SetRow(tbLastNameLabel , 1);  // Specify row for previous grid addition
    Grid.SetColumn(tbLastNameLabel , 0); // Specity column for previous grid addition
    
    grid.Children.Add(tbLastName ); // Add to the grid
    Grid.SetRow(tbLastName , 1);  // Specify row for previous grid addition
    Grid.SetColumn(tbLastName , 1); // Specity column for previous grid addition
