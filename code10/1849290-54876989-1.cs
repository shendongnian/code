	private static IEnumerable<ProductListItem> _productList = null;
	public async Task<IObservable<ProductListItem>> GetProductlistAsync()
	{
	
		var productList = _productList;
		if (productList == null)
		{
			_productList = await _restClient.Get<IEnumerable<ProductListItem>>($"{_serviceUrl}/productlist");
			productList = _productList;
			Observable.Timer(TimeSpan.FromHours(1.0)).Subscribe(x => _productList = null);
		}
		return productList.ToObservable();
	}
