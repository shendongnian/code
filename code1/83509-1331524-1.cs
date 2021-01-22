    public static string ToFriendlyString(this Enum enumType)
    {
        Regex capitalLetterMatch = new Regex("\\B[A-Z]", RegexOptions.Compiled);
        return capitalLetterMatch.Replace(enumType.ToString(), " $&");
    }
