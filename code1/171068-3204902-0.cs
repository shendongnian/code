    string input = "12ACD";
    string digits = new string(input.TakeWhile(c => Char.IsDigit(c)).ToArray());
    int result;
    if (Int32.TryParse(digits, out result))
    {
        Console.WriteLine(result);
    }
