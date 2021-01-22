    /// <summary>
    /// String Extension Method
    /// Adds white space to strings based on Upper Case Letters
    /// </summary>
    /// <example>
    /// strIn => "HateJPMorgan"
    /// preserveAcronyms false => "Hate JP Morgan"
    /// preserveAcronyms true => "Hate JPMorgan"
    /// </example>
    /// <param name="strIn">to evaluate</param>
    /// <param name="preserveAcronyms" >determines saving acronyms (Optional => false) </param>
    public static string AddSpaces(this string strIn, bool preserveAcronyms = false)
    {
        if (string.IsNullOrWhiteSpace(strIn))
            return String.Empty;
        var stringBuilder = new StringBuilder(strIn.Length * 2)
            .Append(strIn[0]);
        int i;
        for (i = 1; i < strIn.Length - 1; i++)
        {
            var c = strIn[i];
            if (Char.IsUpper(c) && (Char.IsLower(strIn[i - 1]) || (preserveAcronyms && Char.IsLower(strIn[i + 1]))))
                stringBuilder.Append(' ');
            stringBuilder.Append(c);
        }
        return stringBuilder.Append(strIn[i]).ToString();
    }
