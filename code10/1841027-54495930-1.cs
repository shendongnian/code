    string input = "This is a sample string with some 1 letter words = a";
    StringBuilder sb = new StringBuilder(input.Length);
    foreach (string word in input.Split())
    {
        if (word.Length > 1) {
            sb.Append(word[0].ToString().ToUpper());
            sb.Append(word.Substring(1));
        }
        else {
            sb.Append(word);
        }
        sb.Append((char)32);
    }
    Console.WriteLine(sb);
