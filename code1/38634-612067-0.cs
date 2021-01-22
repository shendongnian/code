    public static string Trim(this string word, IEnumerable<char> selectedChars)
    {
        // The best form for this will depend largely on the size of selectedChars
        // If you can change how you call the method, there are optimisations you
        // could do here
        HashSet<char> charSet = new HashSet<char>(selectedChars);
        // Give enough capacity for the whole word. Could be too much,
        // but definitely won't be too little
        StringBuilder builder = new StringBuilder(word.Length);
    
        foreach (char c in word)
        {
            if (!charSet.Contains(c))
            {
                builder.Append(c);
            }
        }
        return builder.ToString();
    }
