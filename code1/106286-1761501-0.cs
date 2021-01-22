    // if this is public, it's vulnerable to people setting individual elements.
    private static readonly char[] Vowels = "aeiou".ToCharArray();
    // C# 3
    var nonVowelWorks = str.Split(' ').Where(word => word.IndexOfAny(Vowels) < 0);
    // C# 2
    List<string> words = new List<string>(str.Split(' '));
    words.RemoveAll(delegate(string word) { return word.IndexOfAny(Vowels) >= 0; });
