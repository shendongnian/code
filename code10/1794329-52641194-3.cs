    public BidirectionalGraph Graph 
    {
        get => _graph;
        set 
        {
            _graph=value;
            OnPropertyChanged(nameof(Graph));
        }
    }
    ...
    public async Task MyGraphMethod()
    {
        Graph=graph;
    }
    
