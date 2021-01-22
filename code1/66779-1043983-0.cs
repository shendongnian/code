    public interface TestInterface
    {
       string TestProperty { get; }
    }
    
    public class TestClass : TestInterface
    {
       public string TestProperty
       {
          get { return "test"; }
          set { string t = value; }
       }
    }
