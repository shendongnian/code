        object obj = 
      System.Reflection.Assembly.GetExecutingAssembly().CreateInstance("A");
          var listType = typeof(List<>);
          var constructedListType = listType.MakeGenericType(obj.GetType());
          var instance = Activator.CreateInstance(constructedListType);
