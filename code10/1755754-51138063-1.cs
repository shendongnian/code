    public ToolService(Common.ApplicationSettings settings)
    {
        _dataContext = new DataContext();
        _settings = settings; //settings is null here
    }
