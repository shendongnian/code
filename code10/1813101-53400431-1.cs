    public void RefreshListView(string searchBarText)
    {
        // this can be list clearing, if you need it
        addItemInCollection(searchBarText);
        OnPropertyChanged("LebensmittelList");
    }
    public void addItemInCollection(string searchBarText)
    {
        if (searchBarText != null)
        {
            foreach (var item in normalLebensmittelList)
            {
                if (item.Name.Contains(searchBarText) || item.Name.Contains(searchBarText.First().ToString().ToUpper()))
                {
                    LebensmittelList.Add(item);
                };
            }
        }
    }
