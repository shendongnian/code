    // move 'trim' into an accessible memory location
    private string SanitizeInput (string input) 
    { 
        return input.Trim(trim).Replace(" ", "").ToLower();
    }
    // Having a function like this will change your solution code from the line above to:
    SanitizeInput(y.Attributes("Secondaries).Value).Split(',').ToList();
    // This line is much easier to read as you can tell that the XML parsing is happening, being cleaned, and then manipulated.
