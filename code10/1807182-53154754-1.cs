        static void CalculateAge()
        {
            Console.WriteLine("Enter your year of birth ");
            Console.Write("> ");
            string input = Console.ReadLine();
            int date = 2018;
            Int32.TryParse(input, out date);
            int age = (2018 - date);
            Console.Write("You are " + (age));
            Console.ReadLine();
        }
