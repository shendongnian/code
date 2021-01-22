    public static IEqualityComparer<YourType> MyComparer
    {
       get
         {
          return new GenericEqualityComparer<YourType>((x, y) =>
           {
              return x.name.Equals(y.name);
            });
          }
    }
