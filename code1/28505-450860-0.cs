    public int GetSortedIndex<TKey,TValue>(this SortedList<TKey,TValue> list, TKey key) {
      var comp = list.Comparer;
      for ( var i = 0; i < list.Count; i++ ) {
        if ( comp.Compare(key, list.GetKey(i)) < 0 ) {
          return i;
        }
      }
      return list.Count;
    }
