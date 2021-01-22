    private static List<string> FindPermutations(string set)
        {
            var output = new List<string>();
            if (set.Length == 1)
            {
                output.Add(set);
            }
            else
            {
                foreach (var c in set)
                {
                    // Remove one occurrence of the char (not all)
                    var tail = set.Remove(set.IndexOf(c), 1);
                    foreach (var tailPerms in FindPermutations(tail))
                    {
                        output.Add(c + tailPerms);
                    }
                }
            }
            return output;
        }
