	private void MyObject_PropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		MyObject modifiedItem = sender as MyObject;
		if (e.PropertyName == "IsChecked" && modifiedItem.IsVisible && modifiedItem.IsSelected)
		{
			if (this.LeftListViewDisplayList.Contains(modifiedItem))
			{
				this.PropagateCheck(this._cvsLeftListView, this.LeftListViewDisplayList, modifiedItem.IsChecked);
			}
		}
	}
	private void PropagateCheck(ICollectionView displayedCollection, ObservableCollection<MyObject> storedCollection, bool checkValue)
	{
		List<int> _groupIndices = new List<int>(displayedCollection.Cast<MyObject>().Count());
		foreach (MyObject item in displayedCollection)
		{
			if (item.IsSelected)
			{
				_groupIndices.Add(storedCollection.IndexOf(item));
				item.IsSelected = false;
				item.IsChecked = checkValue;
			}
		}
		foreach (int i in _groupIndices)
		{
			storedCollection[i].IsSelected = true;
		}
		displayedCollection.Refresh();
	}
