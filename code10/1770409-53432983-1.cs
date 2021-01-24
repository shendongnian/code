    public string SearchText { get; set; }
    private List<Shop> _shops;
          
    protected void FilterShops()
        {
        	ComboOpen = true;
        	if (!string.IsNullOrEmpty(SearchText))
        	{
        		Shops.UpdateSource(_shops.Where(s => s.NameExtended.ToLower().Contains(SearchText.ToLower())));
        	}
        	else
        	{
        		Shops.UpdateSource(_shops);
        	}
        	OnPropertyChanged("Shops");
        }
