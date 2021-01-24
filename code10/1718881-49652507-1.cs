    void Tapped(object sender, ItemTappedEventArgs args)
    {
        var listView = sender as ListView;
		var selectedItem = args.Item as ItemViewModel;
		
		// set the text color of the selected item
		foreach (ItemViewModel item in listView.ItemsSource) {
		
			// set the text color
			item.TextColor = selectedItem.Equals(item) ? Color.Green : Color.Black;
			
			// update listView
			item.OnPropertyChanged();
			
		}
	}
