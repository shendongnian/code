    public interface MPropertySettable { }
    public static class PropertySettable {
      public static void SetValue<T>(this MPropertySettable self, string name, T value) {
        self.GetType().GetProperty(name).SetValue(self, value, null);
      }
    }
    public class Foo : MPropertySettable {
      public string Bar { get; set; }
      public int Baz { get; set; }
    }
    class Program {
      static void Main() {
        var foo = new Foo();
        foo.SetValue("Bar", "And the answer is");
        foo.SetValue("Baz", 42);
        Console.WriteLine("{0} {1}", foo.Bar, foo.Baz);
      }
    }
