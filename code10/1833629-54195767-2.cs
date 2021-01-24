    public static Expression<Func<TypeA, TypeB>> Projection
    {
      get
      {   
        return someTypeA => new TypeB
        {
          Info = new TypeB_SubInfo
          {
            prop1 = someTypeA.Whatever,
            // ...
            prop5 = someTypeA.Foobar,
          },
          Items = new List<TypeB_SubItem>()
          {                    
          },
        };
      }
    }
