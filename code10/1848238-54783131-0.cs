    private static List<int> _intItems = new List<int>();
    public static List<int> intItems {
      get { return _intItems; }
      set { _intItems = value ?? new List<int>(); }
    }
