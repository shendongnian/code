    private void CmdAddDrink_Clicked(object sender, RoutedEventArgs e)
    {
        string typeSelection = ((Drinks)DrinkTypeComboBox.SelectedItem).Type;
        Drinks.Add(new Drinks(typeSelection, DrinkNameTextBox.Text)
        {
             IsUserDefined = true
        });
    }
