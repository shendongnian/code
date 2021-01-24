    private readonly TaskDebouncer<Connections[]> _connectionsDebouncer = new TaskDebouncer<Connections[]>();
    
    public ClassName()
    {
        _connectionsDebouncer.OnCompleted += OnConnectionUpdate;
    }
    public void OnConnectionUpdate(Connections[] connections, object sender)
    {
        RunOnMainThread(SearchResult.Clear);
        isAllFriends = false;
        currentPage = 0;
        foreach (var conn in connections)
            RunOnMainThread(() => SearchResult.Add(new ConnectionUser(conn)));
    }
    
    private string searchPhrase;
    public string SearchPhrase
    {
        get => searchPhrase;
        set
        {
            SetProperty(ref searchPhrase, value);
            _connectionsDebouncer.Add(RunInAsync(LoadData));
        }   
    }
    private async Task<Connection[]> LoadData()
    {
        return await connectionRepository
            .GetConnections(currentPage, pageSize, searchPhrase)
            .Where(conn => conn.Type != UserConnection.TypeEnum.Awaiting)
            .ToArray();
    }
