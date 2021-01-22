    private string GetGoodString(string input)
    {
       var allowedChars = 
              Enumerable.Range('0', '9').Concat(
              Enumerable.Range('a', 'z')).Concat(
              Enumerable.Range('-', '-'));
    
       var goodCharsInInput = inputString.Where(c => allowedChars.Contains(c));
       return new string(goodCharsInInput.ToArray());
    }
