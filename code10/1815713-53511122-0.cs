    public class WordStripper
    {
        public string StripWords(string input)
        {
            var ignoreWords = new List<string>
            {
                "CATEGORY:",
                "DATE CREATED:",
                "PRODUCT:",
                "DATE DELETED:"
            };
            var deliminator = string.Join("|", ignoreWords);
            var splitInput = Regex.Split(input, $"({deliminator})");
            var sb = new StringBuilder();
            foreach (var word in splitInput)
            {
                if (ignoreWords.Contains(word))
                {
                    sb.Append(word);
                }
                else
                {
                    var wordLength = word.Length;
                    sb.Append(new string(' ', wordLength));
                }
            }
    
            return sb.ToString();
        }
    }
