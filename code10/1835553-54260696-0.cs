    static string[][] GroupByWord(string[] input, string word)
        {
            var i = 0;
            return input.GroupBy(w =>
            {
                if (w == word)
                {
                    i++;
                    return -1;
                }
                return i;
            })
            .Where(kv => kv.Key != -1) // remove group with "and" strings
            .Select(s => s.ToArray()) // make arrays from groups ["visit", "houston"] for example
            .ToArray(); // make arrays of arrays
        }
