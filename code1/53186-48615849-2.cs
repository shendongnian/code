     public interface INumeric<T>
     {
         T Zero { get; }
         T One { get; }
         T MaxValue { get; }
         T MinValue { get; }
         T Add(T a, T b);
         // T Substract(....
         // T Mult...
     }  
     public struct Numeric: 
         INumeric<int>, 
         INumeric<float>,
         INumeric<byte>,
         INumeric<decimal>,
         // INumeric<other types>
     {
         int INumeric<int>.Zero => 0;
         int INumeric<int>.One => 1;
         int INumeric<int>.MinValue => int.MinValue;
         int INumeric<int>.MaxValue => int.MaxValue;
         int INumeric<int>.Add(int x, int y) => x + y;
  
         // other implementations...
     }
