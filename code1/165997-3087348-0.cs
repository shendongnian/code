     var allTypes = new List<Type>();
     var types = Assembly.GetTypes();
     allTypes.AddRange(types);
     foreach(var type in types)
     {
         allTypes.AddRange(type.GetNestedTypes());
     }
