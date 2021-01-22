    public bool IsConsistent(Func<Foo, bool> property)
    {
      foreach (Foo tempFoo in allFoos)
      {
        if (property(tempFoo) != property(defaultFoo))
          return false;
      }
      return true;
    }
