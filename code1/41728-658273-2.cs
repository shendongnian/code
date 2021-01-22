    public class SomeBadObject {
      public void CallCIndirectly(C obj) { 
        var ret = Helper.CallDoSomething(c);
      }
    }
    
    public static class Helper {
      public int CallDoSomething(C obj) {
        return obj.DoSomething();
      }
    }
