    public new bool this[string key]
    {
        get
        {
            if( this.ContainsKey(key))
               return base[key];
            return default(bool);
        }
        set
        {
            base[key] = value;
            OnPropertyChanged(key.ToString());
        }
    }
