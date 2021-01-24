    abstract class Addable<T>
    {
       public abstract T Add(T X, T Y);
    }
    
    class Number : Addable<Number>
    {
         public int Value;
    
         public Number(int Val)
         {
            Value = Val;
         }
    
         public override Number Add(Number X, Number Y) 
         {
             return new Number(X.Value + Y.Value);
         }
    }
