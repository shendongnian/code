      string text = string.Join(Environment.NewLine, Regex
        .Split(Lines, @"\s{2,}")
        .Select(item => item.Trim())
        .Where(item => item.Length > 0)
        .Select(item => string.Join(Environment.NewLine, 
           Sign1, 
           Sign2 + ToCenter(item, Sign1.Length - 2) + Sign2, 
           Sign3)));
      Console.Write(text);
