    public abstract class MyBaseClass
    {
      public abstract string Name { get; protected set; }
    }
    
    public class MyClass : MyBaseClass
    {
      public override string Name
      {
        get { return "CommandName"; }
        protected set { }
      }
    }
