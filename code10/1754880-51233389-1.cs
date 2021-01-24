    internal static class Program
    {
      private static void Main (string[] args)
      {
        var attr = Attribute.GetCustomAttribute (typeof(Test), typeof(DisplayAttribute)) as DisplayAttribute;
        Console.WriteLine (attr == null ? "no" : "yes");
      }
    }
    
    [DisplayPatch]
    internal class Test
    {
    }
