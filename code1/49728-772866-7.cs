    public HashTable Create(int[] keys, string[] values) { 
      HashTable table = new HashTable();
      for ( int i = 0; i < keys.Length; i++ ) {
        table[keys[i]] = values[i];
      }
      return table;
    }
    
    public Dictionary<object,object> Create(int[] keys, string[] values) {
      Dictionary<object,object> map = Dictionary<object,object>();
      for ( int i = 0; i < keys.Length; i++) {
        map[keys[i]] = values[i];
      }
      return map;
    }
