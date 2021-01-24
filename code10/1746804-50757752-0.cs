    public class Program
    {
        public static void Main(string[] args)
        {
            int numberOfArguments = args.Length;
            if (numberOfArguments > 0)
            {
                Console.WriteLine($"Count: {numberOfArguments} First: {args[0]}");
            }
            else
            {
                Console.WriteLine("No arguments were passed.");
            }
            Console.ReadLine(); // Keep the console open.
        }
    }
