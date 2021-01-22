    public interface IMyInterface { }
    public class SomeType : IMyInterface {}
    public static class TestSpecific
    {
        public static void DoSomething<T>(this IEnumerable<T> source) where T : IMyInterface 
        {
            Console.WriteLine("specific");
        }
    }
    public static class TestGeneral
    {
        public static void DoSomething<T>(this IEnumerable<T> source)
        {
            Console.WriteLine("general");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var general = new List<int>();
            var specific = new List<SomeType>();
            general.DoSomething();
            specific.DoSomething();
            Console.ReadLine();
        }
    }
