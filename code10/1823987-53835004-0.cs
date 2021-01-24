    public bool IsAccepted(String textToValidate)
    {
        Regex strPattern = new Regex("^[a-hA-H]*$");
        if (!strPattern.IsMatch(textToValidate))
        {
            return false;
        }
        return true;
    }
