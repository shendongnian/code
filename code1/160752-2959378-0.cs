    private Dictionary<Type, Type> fooOfBar = new Dictionary<Type, Type>();
    public initialize()
    {
      // you could scan all types in the assembly of a certain base class
      // (fooType) and read the attribute
      
      fooOfBar.Add(attribute.BarType, fooType);
    }
    
    public Foo Make( Bar obj )
    {
      return (Foo)Activator.CreateInstance(fooOfBar(obj.GetType()), obj);
    }
