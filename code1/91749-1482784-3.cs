    public class MyCodeRunner {
     public void runMyCode() {
      //...
     }
    }
    
    public class MyWidget1: ThirdPartyWidget1 {
     private MyCodeRunner myCode = new MyCodeRunner();
     public void myMethod() {
      myCode .runMyCode();
     }
    }
    
    public class MyWidget2: ThirdPartyWidget2 {
     private MyCodeRunner myCode = new MyCodeRunner();
     public void myMethod() {
      myCode .runMyCode();
     }
    }
