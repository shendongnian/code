    var props = new Dictionary<string, string>();
    // ...
    public string this[string key] {
      get { return props[key]; }
      set { props[key] = value; }
    }
