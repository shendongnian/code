            var input = "SaaSingeshe";
            var filteredString = new StringBuilder();
            foreach(char c in input)
            {
                if(filteredString.ToString().IndexOf(c)==-1)
                {
                    filteredString.Append(c);
                }
            }
            Console.WriteLine(filteredString);
            Console.ReadKey();
