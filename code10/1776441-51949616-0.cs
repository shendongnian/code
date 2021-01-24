      private string SplitString(string s, int maxLength)
      {
        string rest = s + " ";
        List<string> parts = new List<string>();
        while (rest != "")
        {
          var part = rest.Substring(0, Math.Min(maxLength, rest.Length));
          var startOfNextString = Math.Min(maxLength, rest.Length);
          var lastSpace = part.LastIndexOf(" ");
          if (lastSpace != -1)
          {
            part = rest.Substring(0, lastSpace);
            startOfNextString = lastSpace;
          }
          parts.Add(part);
          rest = rest.Substring(startOfNextString).TrimStart(new Char[] {' '});
        }
    
        return String.Join(",", parts);
      }
