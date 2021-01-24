        public List<string> FindCombinations(params List<string>[] lists)
        {
            List<string> combinations = lists[0];
            for (int i = 1; i < lists.Length; i++)
            {
                List<string> newCombinations = new List<string>(combinations.Count * lists[i].Count);
                combinations.ForEach(s1 => lists[i].ForEach(s2 => newCombinations.Add($"{s1}_{s2}")));
                combinations = newCombinations;
            }
            return combinations;
        }
