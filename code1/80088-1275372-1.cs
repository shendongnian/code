    public static class Extensions
    {
      public static void WriteFoo(this GeneratedFoo foo, string p)
      {
         MyFoo derived = foo as MyFoo;
         if (derived != null)
         {
            derived.Write(p);
         }
         else
         {
            foo.Write(p);
         }
      }
    }
