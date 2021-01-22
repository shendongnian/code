    bool success = Int32.TryParse(TextBoxD1.Text, out val);
    
    if (success)
    {
    // put val in database
    }
    else
    {
    // handle the case that the string doesn't contain a valid number
    }
