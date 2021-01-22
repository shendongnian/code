     public static class Program
        {
            static void Main()
            {
                Console.WriteLine("Enter string");
                string value = Console.ReadLine();
                value = value.ToLower();
               
                List<string> newList = new List<string>();
                 var results =
                     from e in Enumerable.Range(0, 1 << value.Length)
                     let p =
                     from b in Enumerable.Range(0, value.Length)
                     select (e & (1 << b)) == 0 ? (char?)null : value[b]
                     select string.Join(string.Empty, p);
                foreach (string s in results)
                {
                    string okay = value;
                    s.ToLower();
                    foreach(char c in s)
                    {
                        var Old = c.ToString().ToLower();
                        var New = c.ToString().ToUpper();
                        okay=ReplaceFirstOccurrence(okay, Old, New);
                    }
                    newList.Add(okay);
                }
                foreach(string s in newList)
                {
                    count++;
                    Console.WriteLine(s);
                }            
    
                Console.ReadKey();
            }
            public static string ReplaceFirstOccurrence(string Source, string Find, string Replace)
            {
                int Place = Source.IndexOf(Find);
                string result = Source.Remove(Place, Find.Length).Insert(Place, Replace);
                return result;
            }    
        }
