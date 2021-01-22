            string[] names; //assume there are some names;
            //find all names that start with "a"
            var results = from str in names
                          where str.StartsWith("a")
                          select str;
            //iterate through all names in results and print
            foreach (string name in results)
            {
                Console.WriteLine(name);
            }
