    interface IConverter
    { 
      // general members
    }
    
    interface  IConverter<T, K> : IConverter 
    {
      // typesave members
    }
    
    public IConverter GetConverter(Type type)
    {
      // ...
      return (IConverter)Activator.CreateInstance(type);
    }
