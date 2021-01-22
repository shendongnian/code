    protected void OnPropertyChanged(String prop)
    {
        var eh = PropertyChanged;
        if(eh != null)
        {
            eh(this, new PropertyChangedEventArgs(prop);
            if(DependencyMap.ContainsKey(prop))
            {
                foreach(var p in DependencyMap[prop])
                    OnPropertyChanged(p);//recursive call would allow for arbitrary dependencies
            }
        }
    }
