    public class MyClass {
      MyActualClass _actual;
      public MyClass() {
        _actual = MyActualClass. Instance;
      }
      public DoStuff() {
        _actual.DoStuff();
      }
    }
    
    internal class MyActualClass {
      private MyActualClass {
      }
      public DoStuff() {
        ...
      }
      MyActualClass _instance;
      public static Instance {
        get {
           if(_instance == null)
             _instance = new MyActualClass()
           return _instance;
        }
      }
    }
....
    public static void Main() {
      var my1 = new MyClass();
      var my2 = new MyClass();   
    }
