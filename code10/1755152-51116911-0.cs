    private Dictionary<string, object> _memo = new Dictionary<string, object>();
    public object this[string key]
    {
        get 
        {
            object o;
            _memo.TryGetValue(key, out o);
            return o;
        }
    }
    public void UpdateState()
    {
        _memo["Name"] = Name;
        _memo["Description"] = Description;
        _memo["Alias"] = Alias;
        _memo["Value"] = Value;
        OnPropertyChanged("Item[]");
    }
