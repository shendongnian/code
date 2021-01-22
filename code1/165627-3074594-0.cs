            string input = Console.ReadLine();
            char splitter = ',' ;
            string[] output = input.Split(splitter);
            foreach (string t in output)
            {
                Console.WriteLine(t);
            }
