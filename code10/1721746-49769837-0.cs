      string input = @"1#Artikel1|ArtikelN$2#Artikel1|Artikel2|ArtikelN$3#ArtikelN";
      List<string> result = input
        .Substring(input.IndexOf('#') + 1) 
        .Split(new char[] { '#', '|' }, StringSplitOptions.None) // Either by # or by |
        .Select(item => item.Split(new char[] { '$' }, 2).First())
        .ToList();
      Console.WriteLine(string.Join(Environment.NewLine, result));
