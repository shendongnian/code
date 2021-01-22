    public Dictionary<TKey,TValue> Create<TKey,TValue>(
        IEnumerable<TKey> keys, 
        IEnumerable<TValue> values) {
      Dictionary<TKey,TValue> map = Dictionary<TKey,TValue>();
      using ( IEnumerater<TKey> keyEnum = keys.GetEnumerator() ) {
        using ( IEnumerator<TValue> valueEnum = values.GetEnumerator()) {
          while (keyEnum.MoveNext() && valueEnum.MoveNext() ) { 
            map[keyEnum.Current] = valueEnum.Current;
          }
        }
      }
      return map;
    }
