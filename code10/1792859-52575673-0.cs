        static void Main(string[] args)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            string[] commands = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            
            // Contains is from the System.Linq namespace
            // this will allow you to see if a given value is in the array
            if (commands.Contains("hi"))
            {
                Console.WriteLine("> The command 'hi' has been received.");
            }
            Console.Read();
        }
