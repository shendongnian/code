    class Number : Addable
    {
         public int Value;
    
         public Number(int Val)
         {
            Value = Val;
         }
    
         public override Number Add(Addable X, Addable Y)
         {
             return new Number(X.Value + Y.Value);
         }
    }
