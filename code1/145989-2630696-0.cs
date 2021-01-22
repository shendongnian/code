    namespace A 
    {
      public class B 
      {
          private int c;
          protected int d;
          public void E(int f)
          {
             int g = f;
             Func<int, int> h = i => g * i;
          }
      }
      public class K : B { }
    }
