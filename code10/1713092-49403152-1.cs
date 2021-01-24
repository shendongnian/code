	private ListCollectionView _itemsCollectionView = null;
	public ListCollectionView ItemsCollectionView
	{
		get
		{
			_itemsCollectionView = (ListCollectionView)CollectionViewSource.GetDefaultView(Items);
			_itemsCollectionView.CustomSort = new CategoryComparer(Categories.ToList());
			return _itemsCollectionView;
		}
	}
	
