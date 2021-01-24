    private void MyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    { 
        if(MyListBox.SelectedItem != null)
        {
          var selectedItem = sender as Information;
          //Gives you the Initials of the selected list item
          string intials = selectedItem.Initials;
        } else {
          Debug.WriteLine("No item Selected");
        }
    }
