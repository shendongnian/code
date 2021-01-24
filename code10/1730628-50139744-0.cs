    private IEnumerable<Type> GetAllEntities ()
    {
       var entities = new List<Type> ();
       PropertyInfo[] info = GetType ().GetProperties (BindingFlags.Public | BindingFlags.Instance);
       foreach (PropertyInfo item in info) {
          var setType = item.PropertyType.GetTypeInfo ().GenericTypeArguments[0];
          entities.Add (setType);
       }
       return entities;
    }
