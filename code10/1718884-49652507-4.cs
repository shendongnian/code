    listView.ItemTapped += Tapped;
	var itemsSource = new ObservableCollection<ItemViewModel>{
		new ItemViewModel { Name = "aaa" },
		new ItemViewModel { Name = "bbb" },
		new ItemViewModel { Name = "ccc" },
		new ItemViewModel { Name = "ddd" },
		new ItemViewModel { Name = "eee" },
		new ItemViewModel { Name = "fff" },
	};
	listView.ItemsSource = itemsSource;
