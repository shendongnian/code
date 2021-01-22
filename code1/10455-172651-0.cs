    using System;
    
    class Foo<T>
    {
      public T value;
    
      public void Increment()
      {
       if (value is int) value = (T)(object)(((int)(object)value)+1);
      }
    }
    
    static class Program
    {
        static void Main()
        {
         Foo<int> x = new Foo<int>();
         x.Increment();
         x.Increment();
          Console.WriteLine(x.value); 
        }     
    }
