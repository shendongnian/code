    private ObservableCollection<BinItem> _FromBins = new ObservableCollection<BinItem>();
	public ObservableCollection<BinItem> FromBins
	{
		get
		{
			if (_FromBins.Count > 0)
			{
				List<char> BinsToRemove = new List<char>();
				foreach (var item in _FromBins)
				{
					if (!Map.BinCounts.ContainsKey(item.Bin))
					{
						BinsToRemove.Add(item.Bin);
					}
				} 
				foreach (var item in BinsToRemove)
				{
					_FromBins.Remove(new BinItem(item));
				}
			}
			foreach (var item in Map.BinCounts)
			{
				if (!_FromBins.Contains(new BinItem(item.Key)) && item.Value > 0)					{
					_FromBins.Add(new BinItem(item.Key));
				}
			}
			return _FromBins;
		}
	}
