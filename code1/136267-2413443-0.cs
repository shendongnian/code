    public class Test {
      public int InstanceProperty { get; set; }
      public static void StaticMethod() {
        InstanceProperty = 55; // ERROR HERE
      }
    }
