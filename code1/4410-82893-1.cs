    public static class Text {
      public const string ConstDescription = "This can be used.";
      public readonly static string ReadonlyDescription = "Cannot be used.";
    }
    
    public class Foo 
    {
      [Description(Text.ConstDescription)]
      public int BarThatBuilds {
        { get; set; }
      }
    
      [Description(Text.ReadOnlyDescription)]
      public int BarThatDoesNotBuild {
        { get; set; }
      }
    }
