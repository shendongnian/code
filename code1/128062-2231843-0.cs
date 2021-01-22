    public IEnumerable<string> GetPropertiesSorted(object obj) {
      var type = obj.GetType();
      return type
        .GetProperties()
        .Select(x => new { 
          Value = x.GetValue(obj,null),
          Attribute = (SortAttribute)Attribute.GetCustomAttribute(x, typeof(SortAttribute), false) })
        .OrderBy(x => x.Attribute.Order)
        .Select(x => x.Value)
        .Cast<string>();
    }
