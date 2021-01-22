    public interface TestInterface<T> {
        T MethodHere();
    }
    
    public class test3 : TestInterface<int> {
       int MethodHere() {
          return 2;
       }
    }
