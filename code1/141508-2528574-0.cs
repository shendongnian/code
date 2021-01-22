    public static class Class1 {
      private static EventClass something;
      public static EventClass Something {
        get { return something; }
      }
      static Class1 {
        something = new Class1();
        something.Test += DoStuff;
      }
      public static void DoStuff() {
        ...
      }
    }
