    private void MyComboBox_KeyDown(object sender, KeyRoutedEventArgs args)
    {
        if (e.Key == Windows.System.VirtualKey.E)
        {
            //Now you need to select the first item which starts with letter E.
            //Assuming your combobox's itemssource has a binding to a collection named "MyCollection" then this is how you can achieve it :
            var item = MyCollection.First(a=>a.StartsWith("E"));
            //Now you can set this item to the SelectedItem property of your combobox or you can get its index in the collection and then set SelectedIndex of your combobox.
            var index = MyCollection.IndexOf(item);
            MyComboBox.SelectedIndex = index;//now you have selected the desired item
            //LastStep is to bring that selected item into view of the user.
            MyComboBox.SelectedItem.StartBringIntoView();
        }
    }
