    // logic to validate word goes here
    private static bool IsValidWord(string text)
    {
        double value;
        bool isNumeric = double.TryParse(text, out value);
        // add more validation rules here
        return !isNumeric;
    }
