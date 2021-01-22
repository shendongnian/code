    static string SimpleTemplate(string template, Dictionary<string, string> replacements)
    {
       // parse the message into an array of tokens
       Regex regex = new Regex("(##[^#]+##)");
       string[] tokens = regex.Split(template);
       // the new message from the tokens
       var sb = new StringBuilder((int)((double)template.Length * 1.1));
       foreach (string token in tokens)
          sb.Append(replacements.ContainsKey(token) ? replacements[token] : token);
         
       return sb.ToString();
    }
