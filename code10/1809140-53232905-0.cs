    class Program {
        static void Main(string[] args) {
    
            using(var file = new StreamReader(@"c:\file.csv")) {
                var dict    = new Dictionary<string, List<string>>();
                var letters = new List<string>();
    
                string[] split;
                string line, key;
                
                while((line = file.ReadLine()) != null) {
                    split = line.Split(' ');
                    key = split[0];
                    if(dict.ContainsKey(key)) dict.TryGetValue(key, out letters);
                    else foreach(var letter in split) letters.Add(letter);
                    dict.Add(split[0], letters);
                    letters.Clear();
                }
            }
        }
    }
