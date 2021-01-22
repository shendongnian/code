    public static T BuildObject<T>(SomeClassName obj) where T: AbstractClass 
    {
      T newObject = new T();
      IAbstractClass ac = newObject as IAbstractClass;
      ac.Initialize(obj);
    }
