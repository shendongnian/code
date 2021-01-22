    public static bool IsStrongPassword(string password)
    {
        // Minimum and Maximum Length of field - 6 to 12 Characters
        if (password.Length < 6 || password.Length > 12)
            return false;
        // Special Characters - Not Allowed
        // Spaces - Not Allowed
        if (!(password.All(c => char.IsLetter(c) || char.IsNumeric(c))))  
            return false;
        // Numeric Character - At least one character
        if (!password.Any(c => char.IsNumeric(c)))
            return false;
    
        // At least one Capital Letter
        if (!password.Any(c => char.IsUpper(c)))
            return false;
        return true;
    }
