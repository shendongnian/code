    Expression<Func<T, string, PropertyInfo>> expression = (obj, str) => 
        obj.GetType()
           .GetProperty(
               obj.GetType()
                  .GetProperties()
                  .ToList()
                  .Find(prop =>
                        prop.Equals(str, StringComparison.OrdinalIgnoreCase).Name.ToString());
    var obj = expression.Compile()(rowsData.FirstOrDefault(), sortIndex);
