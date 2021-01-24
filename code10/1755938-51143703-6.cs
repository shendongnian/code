    private void CboColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // Casting the selected item to type Fruits
        var selected = (Fruits)cboColors.SelectedItem;
        // Here I'm setting window title to the selected fruit to illustrate.
        // You can use this however you like.
        this.Title = selected.Fruit;
    }
