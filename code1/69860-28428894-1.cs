    // Create something illegal
    public class Bar2 : IMyInterface
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
    // Our fancy check
    public class Foo<[IsInterface] T>
    {
    }
    class Program
    {
        static Program()
        {
            // Perform all runtime checks
            new NCTChecks(typeof(Program));
        }
        static void Main(string[] args)
        {
            // Normal operation
            Console.WriteLine("Foo");
            Console.ReadLine();
        }
    }
