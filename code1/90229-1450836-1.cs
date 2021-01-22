      string str = "1111222233334444";
      MatchCollection matches = Regex.Matches(str, @"\d{4}");
      string[] groups = (from Match m in matches select m.Value).ToArray<string>();
      // test
      foreach (string group in groups) {
        Console.WriteLine(group);
      }
      // 1111 
      // 2222
      // 3333
      // 4444
