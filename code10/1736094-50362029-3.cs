    bool result = Int32.TryParse(value, out number);
    if (result)
    {
       Console.WriteLine("Converted '{0}' to {1}.", value, number);         
    }
    else
    { 
       Console.WriteLine("Attempted conversion of '{0}' failed.", 
                               value == null ? "<null>" : value);
    }
