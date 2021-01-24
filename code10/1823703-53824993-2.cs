    public static class MyClassDynamic
    {
      public static void MyMethod(dynamic t)
      {
         t.Method(); // Note: if t doesn't have a `Method` defined, the code will crush-n-burn at runtime
      }
    }
