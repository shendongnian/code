    class Number : Addable
    {
         public int Value;
    
         public Number(int Val)
         {
            Value = Val;
         }
    
         public Number Add(Number X, Number Y)
         {
             return new Number(X.Value + Y.Value);
         }
    }
