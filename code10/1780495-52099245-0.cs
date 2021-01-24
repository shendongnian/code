    public bool IsExpanded
    {
        get => _isExpanded;
        set
        {
            _isExpanded = value;
            OnPropertyChanged(nameof(IsExpanded));
        }
    }
    public Match Match
    {
        get => _match;
        set
        {
           _match = value;
           switch (value)
           {
               case Exact:
               case None:
                   IsExpanded = true;
                   break;
               case Multiple:
                   IsExpanded = false;
                   break;
           }
        }
    }
