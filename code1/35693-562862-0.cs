    public struct TypeA
    {
      private int value;
      public TypeA(int value)
      {
        this.value = value;
      }
    
      public static explicit operator int(TypeA a)
      {
         return a.value;
      }
    
      public static explicit operator TypeA(int value)
      {
         return new TypeA(value);
      }
    }
