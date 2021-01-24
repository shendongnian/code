        static void Main(string[] args)
        {
            double fm;
            double fa;
            // Use ReadLine instead of Read 
            Console.WriteLine("Type the value for M in KG:");
            var input = Console.ReadLine();
            // Now you need to cast it to a double - 
            // -- but only if the user entered a valid number 
            if (!double.TryParse(input, out fm))
            {
                Console.WriteLine("Please enter a valid number for M");
                Console.ReadLine(); 
                return; 
            }
            Console.WriteLine("Type the value for A in M/S:");
            input = Console.ReadLine();
            if (!double.TryParse(input, out fa))
            {
                Console.WriteLine("Please enter a valid number for A");
                Console.ReadLine();
                return; 
            }
            // Now we have valid values for fa and fm 
            // It's a better programming practice to use the string format 
            // intead of + here... 
            Console.WriteLine($"Your answer (in Newtowns) is {fm * fa}");
            // You need another read here or the program will just exit
            Console.WriteLine("Please Enter to end the program");
            Console.Read(); 
        }
