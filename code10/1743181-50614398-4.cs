    string GetMatchingWord(Context c, int i)
    {
        switch (c)
        {
            case Context.Noun:
                return Nouns[i];
                break;
            case Context.Adjective:
                return Adjectives[i];
                break;
        }
    }
