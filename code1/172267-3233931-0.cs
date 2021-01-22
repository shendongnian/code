    // define a delegate signature for your functions to implement:
    public delegate void PostProcessingHandler(object sender, object anythingElse /*, etc.*/);
    public class YourClass {
      // define an event that will fire all attached functions:
      public event PostProcessingHandler PostProcess;
      public void YourMethod() {
        while(someConditionIsTrue) {
          // do whatever you need, figure out which function to mark:
          switch(someValue) {
            case "abc": PostProcess += new PostProcessingHandler(HandlerForABC); break;
            case "xyz": PostProcess += new PostProcessingHandler(HandlerForXYZ); break;
            case "123": PostProcess += new PostProcessingHandler(HandlerFor123); break;
            default: break;
          } 
        }
        // invoke the event:
        if(PostProcess != null) { PostProcess(); }
      }
      public void HandlerForABC(object sender, object anythingElse) {  /*...*/  }
      public void HandlerForXYZ(object sender, object anythingElse) {  /*...*/  } 
      public void HandlerFor123(object sender, object anythingElse) {  /*...*/  }
    }
