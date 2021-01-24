    private static string PipeRemove(string value) {
      if (string.IsNullOrEmpty(value))
        return value;
      StringBuilder sb = new StringBuilder(value.Length);
      bool inQuot = false;
      foreach (char c in value) {
        if (c != '|' || !inQuot) // add any char except pipe within quotation
          sb.Append(c); 
        // else // uncomment this if you want space ' ' instead of pipeline '|'
        //   sb.Append(' ');
        if (c == '"')            // states changing
          inQuot = !inQuot;
      }
      return sb.ToString();
    }
    ...
    string test = "MANGO |\"APP | LE \"| GRAPE";
    string result = PipeRemove(test);
    Console.Write(result);
