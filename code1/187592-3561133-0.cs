    string str = reader.GetString(0);
    
    Test test;
    int value;
    if (int.TryParse(str, out value) && Enum.IsDefined(typeof(Test), value))
    {
        test = (Test)value;
    }
    else
    {
        // The string does not represent a valid Test value.
    }
