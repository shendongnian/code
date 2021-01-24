     System.Collections.Generic.Dictionary<string, int> items = new System.Collections.Generic.Dictionary<string, int>();
     byte[] data = wc.DownloadData("https://www.bing.com/search?q=" + keyword);
     MatchCollection M = Regex.Matches(Encoding.UTF8.GetString(data, 0, data.Length), "[a-z]+[:][/][/][a-z]+[.][a-zA-Z0-9]+[.][a-z]+");
     foreach (Match m in M)
     {
         if ( items.ContainsKey(m.Value) )
             items(m.Value) += 1;
         else
             items.Add(m.Value, 1);
     }
    
     System.Collections.Generic.List<string> noDups = items.Where(b => b.Value == 1).Select(c => c.Key).ToList();
