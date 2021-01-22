    public T GetEnumFromString<T>(string value) where T : struct, IConvertible
    {
       if (!typeof(T).IsEnum) 
       {
          throw new ArgumentException("T must be an enumerated type");
       }
       //...
    }
