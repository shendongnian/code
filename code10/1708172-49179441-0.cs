    public sealed class Person
    {
      public TimeSpan Age { get; set; }
    }
    public sealed class Building
    {
      public double Height { get; set; }
    }
    public sealed class Weird 
    {
      public static void M(Func<Person, double> f) {}
      public static void M(Func<Building, double> f) {}
      public static void N() {
        M(x => x.Height);
      }
    }
