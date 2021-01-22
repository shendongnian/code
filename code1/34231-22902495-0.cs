    public object this[string key]
    {
      get
      {
        object obj;
        this.TryGetValue(key, out obj);
        return obj;
      }
      set
      {
        this._dictionary[key] = value;
      }
    }
