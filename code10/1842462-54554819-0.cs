      string Text = "3 stunning private villas <br />   The Beach villa";
      string result = Regex.Replace(
          Text,
        @"(?<=\<br \/\>)\s+",
          match => string.Concat(Enumerable.Repeat("&nbsp;", match.Length)));
 
      Console.Write(result);
