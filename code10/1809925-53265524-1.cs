    public void AddKeyword(string name)
    {
        Keywords.Add(name);
        OnPropertyChanged("Keywords");
    }
    public void RemoveKeyword(string name)
    {
        Keywords.Remove(name);
        OnPropertyChanged("Keywords");
    }
