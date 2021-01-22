        private static List<string> FindPermutations(string set)
        {
            var output = new List<string>();
            if (set.Length == 1)
            {
                output.Add(set);
            }
            else
            {
                var chars = set.ToCharArray();
                foreach (var c in chars)
                {
                    var tail = chars.Except(new List<char>(){c});
                    foreach (var tailPerms in FindPermutations(new string(tail.ToArray())))
                    {
                        output.Add(c + tailPerms);
                    }
                }
            }
            return output;
        }
