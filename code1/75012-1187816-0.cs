    public static int CountVowels(this string value)
    {
        const string vowels = "aeiou";
        return value.GetCharArray().Count(chr => vowels.Contains(char.ToLower(chr)));
    }
