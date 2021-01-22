    private string GetGoodString(string input)
    {
       var allowedChars = 
          Enumerable.Range('0', 10).Concat(
          Enumerable.Range('A', 26)).Concat(
          Enumerable.Range('a', 26)).Concat(
          Enumerable.Range('-', 1));
    
       var goodChars = input.Where(c => allowedChars.Contains(c));
       return new string(goodChars.ToArray());
    }
