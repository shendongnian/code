    private static void ElemInitializer(int ElType, out Element E1)
    {
        E1 = new Element();
        Type typeofElement = typeof(Element);
        Type[] assemblyTypes = Assembly.GetAssembly(T1).GetTypes();
        foreach (Type elementType in assemblyTypes )
        {
          if (elementType.IsSubclassOf(typeofElement))
          {
            var fields = elementType.GetFields();
            foreach (var field in fields)
            {
              if (field.Name == "ElemType")
              {
                 var elementId = (int)field.GetValue(elementType);
                 if (elementId == ElType)
                 {
                    E1 = Activator.CreateInstanceOf(elementType);
                    return;
                 }
               }
             }
           }
         }
    }
