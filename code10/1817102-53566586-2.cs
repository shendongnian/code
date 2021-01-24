    public RelayCommandWithCannotExecuteReason Copy
    {
        get
        {
            if (_copy == null)
            {
                _copy = new RelayCommandWithCannotExecuteReason(
                    x =>
                    {
                        var (name, value) = _tabObjectDictionary[SelectedTabIndex];
                        Clipboard.SetData(name, value);
                    }, x =>
                    {
                        var (name, value) = _tabObjectDictionary[SelectedTabIndex];
                        // Verify your conditions here.
                        return value != null;
                    });
            }
            return _copy;
        }
    }
