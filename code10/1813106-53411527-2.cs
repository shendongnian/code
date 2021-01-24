    private string _searchBarText;
    public string SearchBarText
    {
        get
        {
            return _searchBarText;
        }
        set
        {
            _searchBarText = value;
            OnPropertyChanged("SearchBarText");
        }
    }
    public void RefreshListView()
    {
        if (!string.IsNullOrEmpty(searchBarText))
        {
            var matches = normalLebensmittelList.Where(x => x.Name.Contains(searchBarText) || x.Name.Contains(searchBarText.First().ToString().ToUpper())
            foreach (var item in matches)
            {
              LebensmittelList.Add(item);
            }
        }
    }
