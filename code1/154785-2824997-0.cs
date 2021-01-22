    var list = myString.Split(new String[] {Environment.NewLine},
              StringSplitOptions.RemoveEmptyEntries)                
       .Select(item => item.Split(new char[] {'@'}, 
              StringSplitOptions.RemoveEmptyEntries))
       .Where(a => a.Length > 2)
       .Select(a => new { Item = a[0], Version = a[2] }).ToArray();
