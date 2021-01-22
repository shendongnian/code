            string input = "A_aaA";
            // B
            // The regular expression we use to match
            Regex r1 = new Regex("^[A-Za-z][^.]*$"); //[\t\0x0020] tab and spaces.
            // C
            // Match the input and write results
            Match match = r1.Match(input);
            if (match.Success)
            {
                Console.WriteLine("Valid: {0}", match.Value);
            }
            else
            {
                Console.WriteLine("Not Match");
            }
            Console.ReadLine();
