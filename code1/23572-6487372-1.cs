   class A
   {
      public readonly int Value;
      public override int GetHashCode()
      {
         return Value.GetHashCode(); //OK  Value is read-only and can't be changed during the instance's life time
      }
   }
