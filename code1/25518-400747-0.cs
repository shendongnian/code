    string s = "9quali52ty3";
    StringBuilder result = new StringBuilder();
    foreach(char c in s)
    {
      if (Char.IsLetter(c))  
        result.Add(c);
    }
    Console.WriteLine(result);  // quality
