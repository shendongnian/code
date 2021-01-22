    class Program
    {
        private static List<string> values;
        private const int MAX_PATTERN_LENGTH = 4;
        static void Main(string[] args)
        {
            values = new List<string>();
            values.AddRange(new string[] { "a", "b", "c", "c", "a", "c", "d", "c", "d" });
            
            for (int i = MAX_PATTERN_LENGTH; i > 0; i--)
            {
                RemoveDuplicatesOfLength(i);
            }
            foreach (string s in values)
            {
                Console.WriteLine(s);
            }
        }
        private static void RemoveDuplicatesOfLength(int dupeLength)
        {
            for (int i = 0; i < values.Count; i++)
            {
                if (i + dupeLength > values.Count)
                    break;
                if (i + dupeLength + dupeLength > values.Count)
                    break;
                var patternA = values.GetRange(i, dupeLength);
                var patternB = values.GetRange(i + dupeLength, dupeLength);
                bool isPattern = ComparePatterns(patternA, patternB);
                if (isPattern)
                {
                    values.RemoveRange(i, dupeLength);
                }
            }
        }
        private static bool ComparePatterns(List<string> pattern, List<string> candidate)
        {
            for (int i = 0; i < pattern.Count; i++)
            {
                if (pattern[i] != candidate[i])
                    return false;
            }
            return true;
        }
    }
