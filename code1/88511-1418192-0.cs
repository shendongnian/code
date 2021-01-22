    public class A {
    ...
    private static A _instance = new A();
    public static A Instance() {
      return _instance;
    }
    ...
    }
