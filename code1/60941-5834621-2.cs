    public object GetListOfType(Type t)
    {
      Type listType = typeof(List<>);
      var listOfType = listType.MakeGenericType(t);
      var listOfMyClassInstance = Activator.CreateInstance(listOfType); 
      return listOfMyClassInstance;
    }
