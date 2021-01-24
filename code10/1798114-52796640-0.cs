    private void Add_New_Entry(object sender, RoutedEventArgs e)
    {
        grid.RowDefinitions.Clear();
        for (int x = 0; x < number; x++)
        {
            grid.RowDefinitions.Add(new RowDefinition());
            // ...
            aansluitpin1 = new ComboBox();
            Grid.SetRow(aansluitpin1, x);
            Grid.SetColumn(aansluitpin1, 1);
            // THIS IS THE CHANGE
            // fill each combo box as you create it
            FillComboBox(aansluitpin1);
            // ...
        }
    }
    private void FillComboBox(ComboBox comboBox)
    {
        // same code as aanPinStekKast
        // but modify 'comboBox' instead of AantalPinnenStekkersTestkast
    }
