    string vWord = "65 66 67 97 98 267";
    try
    {
        var CharArray = vWord.Split().Select(n => byte.Parse(n)).ToArray();
        string result = Encoding.ASCII.GetString(CharArray);
        Console.WriteLine($"String result: {result}");
    }
    catch (Exception)
    {
        Console.WriteLine("Not a vaid input");
    }
