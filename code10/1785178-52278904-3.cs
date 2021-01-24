    public class Program
    {
        static Mixed mixed = new Mixed();
        
        static string text = "Hello, World!";
        
        static void Main(string[] args)
        {
            Console.WriteLine("y = " + Mixed.y);
            Console.WriteLine(text);
            Console.WriteLine("y = " + Mixed.y);
            Console.ReadLine();
        }
    }
