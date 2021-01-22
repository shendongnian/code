    string foo = "Mimi loves Toto and Tata hate Mimi so Toto killed Tata";
                HashSet<char> capitals = new HashSet<char>();
                foreach (char c in foo)
                {
                    if (char.IsUpper(c))
                    {
                        capitals.Add(c);
                    }
    
                }
    
                foreach (char ch in capitals)
                {
                    Console.WriteLine(ch);
                }
