    public static int CountVowels(this string value)
    {
        const string vowels = "aeiou";
        return value.Count(chr => vowels.Contains(char.ToLower(chr)));
    }
