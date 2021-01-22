      string pattern = @"^(?!.*(.).*\1)[A-Z]+$";
      string s1 = "ABCDEF";
      string s2 = "ABCDAEF";
      string s3 = "ABCDEBF";
      Console.WriteLine(Regex.IsMatch(s1, pattern));//True
      Console.WriteLine(Regex.IsMatch(s2, pattern));//False
      Console.WriteLine(Regex.IsMatch(s3, pattern));//False
