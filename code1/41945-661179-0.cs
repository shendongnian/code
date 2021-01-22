    public interface IModel {
      void doSomething();
    }
    
    public abstract class AbstractModel : IModel {
      public abstract void doSomething();
    }
    
    public class MyModel : AbstractModel {
      public void doSomething() {
        // code goes here
      }
    }
