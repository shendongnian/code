        static void Main(string[] args)
        {
            char[] inputSet = { 'A', 'B', 'C' };
            var permutations = GetPermutations(new string(inputSet));
            foreach (var p in permutations)
            {
                Console.WriteLine(String.Format("{{{0} {1} {2}}}", p[0], p[1], p[2]));
            }
        }
        public static List<string> GetPermutations(string str)
        {
            List<string> result = new List<string>();
            if (str == null)
                return null;
            if (str.Length == 0)
            {
                result.Add("");
                return result;
            }
            char c = str.ElementAt(0);
            var perms = GetPermutations(str.Substring(1));
            foreach (var word in perms)
            {
                for (int i = 0; i <= word.Length; i++)
                {
                    result.Add(word.Substring(0, i) + c + word.Substring(i));
                }
            }
            return result;
        }
