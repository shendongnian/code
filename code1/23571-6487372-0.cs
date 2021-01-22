   class A
   {
      public int Value;
      public override int GetHashCode()
      {
         return Value.GetHashCode(); //WRONG! Value is not constant during the instance's life time
      }
   }    
