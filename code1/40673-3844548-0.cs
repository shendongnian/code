        this.TestCommand = new DelegateCommand<object>(TestcommandHandler);
        _m = m;
    }
    public List<Movies> lm
    {
        get
        {
            return _m;
        }
    }
