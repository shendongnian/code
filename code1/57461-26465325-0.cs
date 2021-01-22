    if (!string.IsNullOrEmpty(stringTest))
    {
        stringTest.All(char.IsDigit);
    }
    else
    {
        //Add Logging: Null string would pass the test of being Numeric.
    }
