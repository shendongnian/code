    /// <summary>
    /// A dictionary that holds the collection of previous title case
    /// conversions so they don't have to be done again if needed more than once.
    /// </summary>
    private static Dictionary<string, string> _prevTitleCaseConversions = new Dictionary<String, String>();
    /// <summary>
    /// A collection of English words that should be lower-case in title-cased phrases.
    /// </summary>
    private static List<string> _englishTitleCaseLowerCaseWords = new List<string>() {"aboard", "about", "above", "across", "after",
        "against", "along", "amid", "among", "anti", "around", "is", "as", "at", "before", "behind", "below",
        "beneath", "beside", "besides", "between", "beyond", "but", "by", "concerning", "considering",
        "despite", "down", "during", "except", "excepting", "excluding", "following", "for", "from", "in",
        "inside", "into", "like", "minus", "near", "of", "off", "on", "onto", "opposite", "outside", "over",
        "past", "per", "plus", "regarding", "round", "save", "since", "than", "through", "to", "toward",
        "towards", "under", "underneath", "unlike", "until", "up", "upon", "versus", "via", "with", "within", "without",
        "and", "but", "or", "nor", "for", "yet", "so", "although", "because", "since", "unless", "the", "a", "an"};
    /// <summary>
    /// Convert the provided alpha-numeric string to title case.  The string may contain spaces in addition to letters and numbers, or it can be
    /// one individual lowercase, uppercase, or camel case token.
    /// </summary>
    /// <param name="forValue">The input string which will be converted.  The string can be a 
    /// normal string with spaces or a single token in all lowercase, all uppercase, or camel case.</param>
    /// <returns>A version of the input string which has had spaces inserted between each internal "word" that is 
    /// delimited by an uppercase character and which has otherwise been converted to title case, i.e. all 
    /// words except for conjunctions, prepositions, and articles are upper case.</returns>
    public static string ToTitleCase(this string forValue)
    {
        if (string.IsNullOrEmpty(forValue)) return forValue;
        if (!Regex.IsMatch(forValue, "^[A-Za-z0-9 ]+$"))
            throw new ArgumentException($@"""{forValue}"" is not a valid alpha-numeric token for this method.");
        if (_prevTitleCaseConversions.ContainsKey(forValue)) return _prevTitleCaseConversions[forValue];
        var tokenizedChars = GetTokenizedCharacterArray(forValue);
        StringBuilder wordsSB = GetTitleCasedTokens(tokenizedChars);
        string ret = wordsSB.ToString();
        _prevTitleCaseConversions.Add(forValue, ret);
        return ret;
    }
    /// <summary>
    /// Convert the provided string such that first character is 
    /// uppercase and the remaining characters are lowercase.
    /// </summary>
    /// <param name="forInput">The string which will have 
    /// its first character converted to uppercase and 
    /// subsequent characters converted to lowercase.</param>
    /// <returns>The provided string with its first character 
    /// converted to uppercase and subsequent characters converted to lowercase.</returns>
    private static string FirstUpper(this string forInput)
    {
        return Alter(forInput, new Func<string, string>((input) => input.ToUpperInvariant()), new Func<string, string>((input) => input.ToLowerInvariant()));
    }
    /// <summary>
    /// Return an array of characters built from the provided string with 
    /// spaces in between each word (token).
    /// </summary>
    private static ReadOnlyCollection<char> GetTokenizedCharacterArray(string fromInput)
    {
        var ret = new List<char>();
        var tokenChars = fromInput.ToCharArray();
        bool isPrevCharUpper = false;
        bool isPrevPrevCharUpper = false;
        bool isPrevPrevPrevCharUpper = false;
        bool isNextCharUpper = false;
        bool isNextCharSpace = false;
        for (int i = 0; i < tokenChars.Length; i++)
        {
            char letter = tokenChars[i];
            bool addSpace;
            bool isCharUpper = char.IsUpper(letter);
            if (i == 0) addSpace = false; // no space before first char.
            else
            {
                bool isAtLastChar = i == tokenChars.Length - 1;
                isNextCharUpper = !isAtLastChar && char.IsUpper(tokenChars[i + 1]);
                isNextCharSpace = !isAtLastChar && !isNextCharUpper && tokenChars[i + 1].Equals(' ');
                bool isInAcronym = (isCharUpper && isPrevCharUpper && (isAtLastChar || isNextCharSpace || isNextCharUpper));
                addSpace = isCharUpper && !isInAcronym;
            }
            if (addSpace) ret.Add(' ');
            ret.Add(letter);
            isPrevPrevPrevCharUpper = isPrevPrevCharUpper;
            isPrevPrevCharUpper = isPrevCharUpper;
            isPrevCharUpper = isCharUpper;
        }
        return ret.AsReadOnly();
    }
    /// <summary>
    /// Return a string builder that will produce a string which contains
    /// all the tokens (words separated by spaces) in the provided collection
    /// of characters and where the string conforms to title casing rules as defined above.
    /// </summary>
    private static StringBuilder GetTitleCasedTokens(IEnumerable<char> fromTokenChars)
    {
        StringBuilder wordsSB = new StringBuilder();
        var comparer = StringComparer.Create(System.Globalization.CultureInfo.CurrentCulture, true);
        var words = new string(fromTokenChars.ToArray()).Split(' ');
        bool isFirstWord = true;
        foreach (string word in words)
        {
            if (word.Length == 0) continue;
            if (wordsSB.Length > 0) wordsSB.Append(' ');
            bool isAcronym = word.Length > 1 && word.All((c) => char.IsUpper(c));
            string toAppend;
            // leave acronyms as-is, and lower-case all title case exceptions unless it's the first word.
            if (isAcronym) toAppend = word;
            else if (isFirstWord || !_englishTitleCaseLowerCaseWords.Contains(word, comparer)) toAppend = word.FirstUpper();
            else toAppend = word.ToLower();
            wordsSB.Append(toAppend);
            isFirstWord = false;
        }
        return wordsSB;
    }
    /// <summary>
    /// Convert the provided string such that first character is altered using 
    /// <paramref name="firstCharAlterationFunction"/> and the remaining characters
    /// are altered using <paramref name="remainingCharsAlterationFunction"/>.
    /// </summary>
    /// <param name="forInput">The string which will have 
    /// its first character altered using <paramref name="firstCharAlterationFunction"/> and 
    /// subsequent characters altered using <paramref name="remainingCharsAlterationFunction"/>.</param>
    /// <param name="firstCharAlterationFunction">The function which will
    /// be used to alter the first character of the input string.</param>
    /// <param name="remainingCharsAlterationFunction">The function which
    /// will be used to ever character in the string after the first character.</param>
    /// <returns>The provided string with its first character 
    /// altered using <paramref name="firstCharAlterationFunction"/> and 
    /// subsequent characters altered using <paramref name="remainingCharsAlterationFunction"/>.</returns>
    private static string Alter(string forInput, Func<string, string> firstCharAlterationFunction, Func<string, string> remainingCharsAlterationFunction)
    {
        if (string.IsNullOrWhiteSpace(forInput)) return forInput;
        if (forInput.Length == 1) return firstCharAlterationFunction(forInput);
        return firstCharAlterationFunction(forInput[0].ToString()) + remainingCharsAlterationFunction(forInput.Substring(1));
    }
