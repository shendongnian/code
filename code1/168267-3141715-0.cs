        string sPattern = "ja";
        foreach (string s in words)
        {
            
            if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                System.Console.WriteLine("  (match for '{0}' found)", sPattern);
            }
          
        }
