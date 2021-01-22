    public class Base {
      protected virtual void DoSomething() {
        // do nothing
      }
      public Base() {
        DoSomething();
      }
    }
    public class Another : Base {
      private List<string> list;
      
      public Another() {
        list = new List<string>();
      }
      protected override void DoSomething() {
        // this code will raise NullReferenceException,
        // since this class' constructor was not run yet,
        // still, this method was run, since it was called
        // from the Base constructor
        list.Add("something");
      }
    }
