    public static Expression<Func<TypeA, TypeB>> Projection
    {
      get
      {   
        return someTypeA =>
        {
          var tInfo = new TypeB_SubInfo
          {
            prop1 = someTypeA.Whatever,
            // ...
            prop5 = someTypeA.Foobar,
          };
          var tItems = new List<TypeB_SubItem>()
          {                    
          };
          return new TypeB
          {
            Items = tItems,
            Info = tInfo,
          };
        }
      }
    }
