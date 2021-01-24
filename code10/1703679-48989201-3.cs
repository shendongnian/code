    private void MyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    { 
       var selectedItem = sender as SomeClassName;
       //Gives you the Initials of the selected list item
       string intials = selectedItem.Initials;
    }
