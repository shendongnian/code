       if (KeywordList
             .Text
             .Split(new char[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries)
             .Any(item => item.Length <= 4)) 
         Response.Write("Please enter min 5 characters per line");
       else
         Response.Write("success");
