    public static Foo CreateInstance(string objectIdentifer)
    {
       if (objectIdentifier == "Child1")
       {
          return (Foo)Activator.CreateInstance(Type.GetType("Foo.FooChild1, FooChild1"));
       }
       else
       {
          return (Foo)Activator.CreateInstance(Type.GetType("Foo.FooChild1, FooChild2"));
       }
    }
