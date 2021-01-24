    _view = CollectionViewSource.GetDefaultView(sourceCollection);
    _view.Filter = (obj) => 
    {
        GameList game = obj as GameList;
        return game != null && game.Title?.Contains(_searchString);
    };
    ...
    public string SearchString
    {
        ...
        set { _searchString = value; _view.Refresh(); }
    }
