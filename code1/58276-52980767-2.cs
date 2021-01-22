     public static class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter string");
            string value = Console.ReadLine();
            value = value.ToLower();
            List<string> list = new List<string>();
             var results =
                 from e in Enumerable.Range(0, 1 << value.Length)
                 let p =
                 from b in Enumerable.Range(0, value.Length)
                 select (e & (1 << b)) == 0 ? (char?)null : value[b]
                 select string.Join(string.Empty, p);
            foreach (string s in results)
            {
                string newValue = value;
                s.ToLower();
                foreach(char c in s)
                {
                    var Old = c.ToString().ToLower();
                    var New = c.ToString().ToUpper();
                    newValue=ReplaceFirstOccurrence(newValue, Old, New);
                }
                list.Add(newValue);
            }
            foreach(string s in list)
            {
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
