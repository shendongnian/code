    public static IMyTypeRepository  GetRepository(Type t)
    {
       if(t == typeof(Type1))
       {
          return Type1Repository();
       }
    
       if(t == typeof(Type2))
       {
          return Type2Repository();
       }
       .......
    }
