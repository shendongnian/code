    if (input is string)
    {
        // test for legal characters?
        string pattern = "^[A-Za-z]+$";
        if (Regex.IsMatch(input, pattern))
        {
             // legal string? do something 
        }
        // or
        if (input.Any(c => !char.IsLetter(c)))
        {
             // NOT legal string 
        }
    }
