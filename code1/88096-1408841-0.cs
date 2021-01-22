    public ActionResult TestControllerAction()
    {
         var action = new TestControllerAction();
         var objectWithBehaviorBasedOnAction = new MyObjectWithBehaviorBasedOnAction();
         objectWithBehaviorBasedOnAction.DoSomething(action);    
    }
    public class MyObjectWithBehaviorBasedOnAction: IMyBehaviorBasedOnAction
    {
        public void DoSomething(IControllerAction action)
        {
          // generic stuff
        }
        public void DoSomething(TestControllerAction action)
        {
           // do behavior A
        }
        public void DoSomething(OtherControllerAction action)
        {
            // do behavior b
        }
    }
    public interface IMyBehaviorBasedOnAction
    {
       void DoSomething(IControllerAction action);
    }
