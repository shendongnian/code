    public class MyClass : ISomething {
      private MyClass(){} // private constructor
      public ISomething  GetClass(){ // factory method
        return new MyClass();
      }
    }
