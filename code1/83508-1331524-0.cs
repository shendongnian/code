    public static string GetDescriptionOf(Enum enumType)
    {
        Regex capitalLetterMatch = new Regex("\\B[A-Z]", RegexOptions.Compiled);
        return capitalLetterMatch.Replace(enumType.ToString(), " $&");
    }
