    public class MyClass {
      private static readonly someStaticField;
      
      static MyClass() { someStaticField = ... }
      // any no-op method call accepting your object will do fine
      public static void TouchMe() { Equals(someStaticField, null); }
    }
