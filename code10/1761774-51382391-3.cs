    public class Option
    {
        public string Description { get; }
        public string Method { get; }
        public Option(string description, string method)
        {
            Description = description;
            Method = method;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            var options = new[]
            {
                new Option("1 to print \"Hello\".", "PrintHello"),
                new Option("2 to print \"World\".", "PrintWorld")
            };
            
            Console.WriteLine("Please press the number of the desired option:");
            foreach (var option in options)
            {
                Console.WriteLine($"{option.Description}");
            }
            char key;
            while (true)
            {
                key = Console.ReadKey().KeyChar;
                if (key >= '1' && key <= '0' + options.Length)
                {
                    break;
                }
                Console.WriteLine($"{Environment.NewLine}Please choose an option from 1 to {options.Length}");
            }
            Console.WriteLine($"{Environment.NewLine}You selected option {key}");
            var selected = options[key - '1'];
            typeof(Program).GetMethod(selected.Method).Invoke(null, null);
            // This line is just to stop the console window closing
            Console.ReadLine();
        }
        public static void PrintHello()
        {
            Console.WriteLine("Hello");
        }
        public static void PrintWorld()
        {
            Console.WriteLine("World");
        }
    }
