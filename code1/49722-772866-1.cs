    public Dictionary<int,string> Create(int[] keys, string[] values) {
      Dictionary<int,string> map = Dictionary<int,string>();
      for ( int i = 0; i < keys.Length; i++) {
        map[keys[i]] = values[i];
      }
      return map;
    }
