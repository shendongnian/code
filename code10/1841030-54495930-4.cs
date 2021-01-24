    string input = "this is a sample, string with: some => 1 letter words ! a";
    StringBuilder sb = new StringBuilder(input.Length * 2);
    foreach (string word in input.Split())
    {
        if (word.Length > 1) {
            sb.Append(char.ToUpper(word[0]));
            sb.Append(word.Substring(1));
        }
        else {
            sb.Append(word);
        }
        sb.Append((char)32);
    }
    Console.WriteLine(sb);
