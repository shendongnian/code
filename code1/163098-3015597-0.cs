      public struct MyCustomInteger
      {
         private int val;
         private bool isDef;
         public bool HasValue { get { return isDef; } } 
         public int Value { return val; } } 
         private MyCustomInteger() { }
         private MyCustomInteger(int intVal)
         { val = intVal; isDef = true; }
         public static MyCustomInteger Make(int intVal)
         { return new MyCustomInteger(intVal); }
         public static NullInt = new MyCustomInteger();
    
         public static explicit operator int (MyCustomInteger val)
         { 
             if (!HasValue) throw new ArgumentNullEception();
             return Value;
         }
         public static implicit operator MyCustomInteger (int val)
         {  return new MyCustomInteger(val); }
      }
  
