    public class Test {
      public static int StaticProperty { get; set; }
      public static void StaticMethod() {
        StaticProperty = 55; // Ok
      }
    }
    public class Test {
      public int InstanceProperty { get; set; }
      public void InstanceMethod() {
        InstanceProperty = 55; // Ok
      }
    }
