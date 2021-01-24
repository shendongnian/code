    public ICollectionView StripeCollection
    {
    	get { return _stripeCollection; }
    	set
    	{
    		_stripeCollection = value;
    		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StripeCollection)));
    	}
    }
    private ICollectionView _stripeCollection =new CollectionView(MyZebra.Stripes);
    MyZebra.StripesChanged += (sender, args) => {StripeCollection.Refresh();};
