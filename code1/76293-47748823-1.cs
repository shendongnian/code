    public static class StringExtensions
    {
        /// <summary>
        /// Title case example: 'Some Text In Your Page'.
        /// </summary>
        /// <param name="text">Support camel and title cases combinations: 'someText in YourPage'</param>
        public static string ToTitleCase(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }
            var result = string.Empty;
            var splitedBySpace = text.Split(new[]{ ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var sequence in splitedBySpace)
            {
                // let's check the letters. Sequence can contain even 2 words in camel case
                for (var i = 0; i < sequence.Length; i++)
                {
                    var letter = sequence[i].ToString();
                    // if the letter is Big or it was spaced so this is a start of another word
                    if (letter == letter.ToUpper() || i == 0)
                    {
                        // add a space between words
                        result += ' ';
                    }
                    result += i == 0 ? letter.ToUpper() : letter;
                }
            }            
            return result.Trim();
        }
    }
