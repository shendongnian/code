    public class Program
    {
        public static void Main()
        {
            System.Console.WriteLine(new Program().Foo());
        }
    
        public string Foo() // notice this is NOT static anymore
        {
            return "Foo";
        }
    }
