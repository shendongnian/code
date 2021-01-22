    void Main()
    {
        var output = "This is a test".WithoutSingleCharacterWords();
    }
    
    public static class StringExtensions
    {
        public static string WithoutSingleCharacterWords(this string input)
        {
            var longerWords = input.Split(' ').Where(x => x.Length != 1).ToArray();
            return string.Join(" ", longerWords);
        }
    }
