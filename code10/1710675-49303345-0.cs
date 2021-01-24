            string line1 = "What is your name: Alain";
            Regex rgex = new Regex(@"(?<=:\s)(.*)", RegexOptions.Compiled);
            Match match = rgex.Match(line1);            
            if (match.Success)
            {
                Console.WriteLine("Name= " + match.Value);
            }
            Console.ReadKey();
