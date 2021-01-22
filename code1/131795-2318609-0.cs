    class Program
    {
        static void Main(string[] args)
        {
            var original = new List<Bar>();
            IEnumerable<IFoo> foos = original.Cast<IFoo>();
        }
    }
    public interface IFoo { }
    public class Bar : IFoo { }
