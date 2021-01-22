    public List<string> BreakStringIntoLines(string s, int lineWidth)
    {
         string working = s;
         List<string> result = new List<string>(Math.Ceil((double)s.Length / lineWidth));
         while (working.Length > lineWidth)
         {
              result.add(working.Substring(0, lineWidth);
              working = working.Substring(5);
         }
    
         result.Add(working);
    
         return result;
    }
