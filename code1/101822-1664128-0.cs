    interface ISomething {
       event EventHandler MyEvent;
    }
    
    internal class MyClass : ISomething {
      ... 
    }
    
    public ClassFactory {
      public ISomething GetClass(){ // factory method
        return new MyClass();
      }
    }
