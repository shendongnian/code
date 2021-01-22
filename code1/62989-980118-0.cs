        static Dictionary<string, int> CountWords(string[] words) {
            // use (StringComparer.{your choice}) for case-insensitive
            var result = new Dictionary<string, int>();
            foreach (string word in words) {
                int count;
                if (result.TryGetValue(word, out count)) {
                    result[word] = count + 1;
                } else {
                    result.Add(word, 1);
                }
            }
            return result;
        }
            ...
            var set1 = CountWords(word);
            var set2 = CountWords(word2);
            var matches = from val in set1
                          where set2.ContainsKey(val.Key)
                             && set2[val.Key] == val.Value
                          select val.Key;
            foreach (string match in matches)
            {
                Console.WriteLine(match);
            }
