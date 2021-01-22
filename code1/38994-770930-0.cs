    public class Type1Factory
    {
      private Type3 type3;
    
      public Type1Factory(Type3 _type3)
      {
         type3 = _type3;
      }
    
      public GetType1(Type2 type2)
      {
        return new Type1(type2, type3);
      }
    }
