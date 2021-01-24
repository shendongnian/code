    public class Container
    {
         public static string DefaultName => DefaultGroup.Name;
         public static decimal DefaultPrice => DefaultGroup.Price;
         public static Group DefaultGroup { get; } = new Group("default name", 10m);
    }
