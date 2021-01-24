    class Program {
            static void Main(string[] args) {
    
                using(var file = new StreamReader(@"../file.csv")) {
                    var dict = new Dictionary<string, List<string>>();
                    List<string> split;
                    string line, key;
    
                    while((line = file.ReadLine()) != null) {
                        split = line.Select(l => new string(l, 1)).Where(l => l != " ").ToList();
                        key   = split[0];
                        split.RemoveAt(0);
    
                        if(dict.ContainsKey(key)) { 
                            dict.TryGetValue(key, out var values);
                            values.AddRange(split);
                        } else dict.Add(key, split);
                    }
    
                    foreach(KeyValuePair<string, List<string>> r in dict) {
                        foreach(var val in r.Value) {
                            Console.WriteLine("Main = {0}, Sub = {1}", r.Key, val);
                        }
                    }
                }
            }
        }
