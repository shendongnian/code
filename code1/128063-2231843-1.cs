    public IEnumerable<object> GetPropertiesSorted(object obj) {
      Type type = obj.GetType();
      List<KeyValuePair<object,int>> list = new List<KeyValuePair<object,int>>();
      foreach ( PropertyInfo info in type.GetProperties()) {
        object value = info.GetValue(obj,null);
        SortAttribute sort = (SortAttribute)Attribute.GetCustomAttribute(x, typeof(SortAttribute), false);
        list.Add(new KeyValuePair<object,int>(value,sort.Order));
      }
      list.Sort(delegate (KeyValuePair<object,int> left, KeyValuePair<object,int> right) { left.Value.CompareTo right.Value; });
      List<object> retList = new List<object>();
      foreach ( var item in list ) {
        retList.Add(item.Key);
      }
      return retList;
    }
