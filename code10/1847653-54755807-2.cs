    public static string NormalizePhone(string phone)
    {
        // **We should give the user the benefit of the doubt.**
        // I don't care what crazy format they used, if there are 10 digits, we can handle it.
        //remove anything not a digit
        var digits = Regex.Replace(phone, @"[^\d]", ""); 
      
        //ensure exactly 10 characters remain
        if (digits.Length != 10) throw new InvalidArgumentException($"{phone} is not a valid phone number in this system.");
        return digits;
    }
    // Phone argument should be pre-normalized,
    //    because we want to be able to use this method with strings retrieved
    //    from storage without having to re-normalize them every time.
    //    Remember, you'll show a repeat value more often than you receive new values.
    public static string FormatPhone(string phone)
    {
        return Regex.Replace(phone, @"(\d{3})(\d{3})(\d{4})", "($1) $2 - $3");
    }
