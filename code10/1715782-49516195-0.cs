    // test with a 29 digit number
    string input = "564654564553314342340968580654";
    for (int i = 0; i < input.Length - 16+1; i++)
    {
        string result = string.Concat(input.Skip(i).Take(16));
        if (result.All(x => char.IsDigit(x)))
        {
            Console.WriteLine(result);
        }
    }
