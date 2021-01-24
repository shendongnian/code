    string text = " Ph0b0x � ";
    string result = Regex.Replace(text, @"[^\x00-\x7F]+", "");
    Console.WriteLine(text);
    Console.WriteLine(result);
    Console.ReadLine();
