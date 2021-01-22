    public class Configuration
    {
      [Export("SomeValue")]
      public string SomeValue
      {
        get { /* return value from database perhaps? */ }
      }
    }
    [Export(typeof(IRule))]
    public class RuleInstance : IRule
    {
      [Import("SomeValue")]
      public string SomeValue { get; private set; }
    }
