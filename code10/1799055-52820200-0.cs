    public ListViewModel()
    {
        Games = new ObservableCollection<Game>();
    }
    ...
    public ObservableCollection<Game> Games { get; }
    public void refreshGames()
    {
        Games.Clear()
        ...
        // add items to Games collection here
    }
