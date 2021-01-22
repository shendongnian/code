    public bool IsConsistent<T>(Func<Foo, T> property)
      where T : struct
    {
      foreach (Foo tempFoo in allFoos)
      {
        if (!property(tempFoo).Equals(property(defaultFoo)))
          return false;
      }
      return true;
    }
