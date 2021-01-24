    if (Int32.TryParse(text, out ignoreMe))
    {
        listOfNumbersNum.Add(ignoreMe);
    }
    // Console.ReadLine() will never return null, so you can remove that check
    else if (text.Equals("ok", StringComparison.OrdinalIgnoreCase))
    {
        // And since you only use sum once, you don't need to capture it in a variable
        Console.WriteLine("Result of sum: " + listOfNumbersNum.Sum());
        isOk = true;
    }
