    string parts = s.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
    foreach (string word in parts)
    {
      Console.WriteLine(word);
    }
