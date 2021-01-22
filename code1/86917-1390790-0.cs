    private static char[] characters = new char [] { '*','&',... };
    public static bool ContainsOneCharacter(string text)
    {
        var intersection = text.Intersect(characters).ToList();
        if( intersection.Count != 1)
            return false; // Make sure there is only one character in the text
        // Get a count of all of the one found character
        if (1 == text.Count(t => t == intersection[0]) )
            return true;
        return false;
    }
