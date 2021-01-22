    class Program
    {
      static void Main(string[] args)
      {
         B bValue = new B(123);
         Console.WriteLine(typeof(A).IsAssignableFrom(bValue.GetType()));
         //Console.WriteLine(bValue is A);
         //Console.WriteLine(bValue as A == null);
         A aValue = bValue;
         Console.WriteLine(aValue.ToString());
      }
    }
    class A
    {
      string value;
      public A(string value)
      {
         this.value = value;
      }
      public override string ToString()
      {
         return value;
      }
    }
    class B
    {
      int value;
      public B(int value)
      {
         this.value = value;
      }
      public static implicit operator A(B value)
      {
         return new A(value.value.ToString());
      }
    }
