    public TResult Execute<TResult>(...) 
    {
      if (typeof(TResult) is MyBaseClass)
      {
          Type mytype = typeof(TResult);
          MethodInfo method = typeof({TypewhereFoo<>IsDeclared}).GetMethod("Foo");
          MethodInfo generic = method.MakeGenericMethod(myType);
          return (TResult)generic.Invoke(this, null);
      }
      else
      {
         // Throw here
      }
    }
