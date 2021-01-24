    static void Main(string[] args) {
            string str = "FB:77:CB:0B:EC:09{W: 0,623413, X: 0,015374, Y: 0,005306, Z: -0,781723}";
            char[] delims = { ':', ' ' };
            var parsed = Parse(str, delims);
            foreach (var p in parsed) {
                Console.WriteLine($"{p.Key} : {p.Value}");
            }
        }
        static Dictionary<string, double> Parse(string input, char[] delims) {
            int first = input.IndexOf('{') + 1;
            int second = input.IndexOf('}');
            string str2 = input.Substring(first, second - first);
            string[] strArray = str2.Split(delims, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, double> pairs = new Dictionary<string, double>();
            for (int i = 1; i < strArray.Length; i++) {
                if (strArray[i].Contains(",")) {
                    if (double.TryParse(strArray[i].Substring(0, strArray[i].Length - 1), out double result)) {
                        pairs.Add(strArray[i - 1], result);
                    }
                    i++;
                }
            }
            return pairs;
        }
