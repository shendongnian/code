    List<string> _Data;
    public IEnumerable<string> Data
    {
      get
      {
        foreach(string item in _Data)
        {
          return yield item;
        }
      }
    }
