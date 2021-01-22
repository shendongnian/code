        public static string SplitLongWords(string text, int maxWordLength)
        {
            var reg = new Regex(@"\S{" + (maxWordLength + 1) + ",}");
            bool replaced;
            do
            {
                replaced = false;
                text = reg.Replace(text, (m) =>
                {
                    replaced = true;
                    return m.Value.Insert(maxWordLength, " ");                    
                });
            } while (replaced);
            return text;
        }
