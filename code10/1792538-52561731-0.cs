    if (Int32.TryParse(text, out ignoreMe))
    {
        listOfNumbersNum.Add(ignoreMe);
    }
    else if (text.Equals("ok", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("Result of sum: " + listOfNumbersNum.Sum());
        isOk = true;
    }
