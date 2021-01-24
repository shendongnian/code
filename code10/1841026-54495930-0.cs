    string input = "This is a sample string with some 1 letter words = a";
    StringBuilder sb = new StringBuilder(input.Length);
    foreach (string word in input.Split())
    {
        sb.Append(((word.Length > 1) 
                    ? word[0].ToString().ToUpper() + word.Substring(1) : word) + (char)32);
    }
    Console.WriteLine(sb);
