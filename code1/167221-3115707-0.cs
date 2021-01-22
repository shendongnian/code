    public bool IsValidName(string theString)
    {
        for (int i = 0; i < theString.Length - 1; i++)
        {
            if (!char.IsLetter(theString[i]) && !char.IsWhiteSpace(theString[i]))
            {
                return false;
            }
        }
        return true;
    }
