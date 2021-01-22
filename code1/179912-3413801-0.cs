    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<string> data = new List<string>() { "[66,X,X]", "[67,X,2]", "[x,x,x]" };
                addToDict(data);
    
                Console.ReadKey();
            }
    
            private static void addToDict(List<string> items)
            {
                string key = items[0].Split('[', ',')[1];
                string val = items[1].Split('[', ',')[1];
    
                string pattern = @"(?:^\[)(\d+)";
                Match m = Regex.Match(items[0], pattern);
                key = m.Groups[1].Value;
                m = Regex.Match(items[1], pattern);
                val = m.Groups[1].Value;
    
                _dict.Add(key, val);
            }
    
            static Dictionary<string, string> _dict = new Dictionary<string, string>();
        }
    }
