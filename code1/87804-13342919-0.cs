        private static IEnumerable<string> CustomSplit(string newtext, char splitChar)
        {
            var result = new List<string>();
            var sb = new StringBuilder();
            foreach (var c in newtext)
            {
                if ((c == splitChar))
                {
                    if (sb.Length > 0)
                    {
                        result.Add(sb.ToString());
                        sb.Clear();
                    }
                    continue;
                }
                sb.Append(c);
            }
            if (sb.Length > 0)
            {
                result.Add(sb.ToString());
            }
            return result;
        }
