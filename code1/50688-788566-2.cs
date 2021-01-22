    public static string CommaQuibbling(IEnumerable<string> items)
    {
      int count = items.Count();
      string answer = string.Empty;
      return "{" + 
          (count==0)  ?  ""  :  
             (  items[0] + 
                 (count == 1 ? "" :  
                     items.Range(1,count-1).
                         Aggregate(answer, (s,a)=> s += ", " + a) +
                     items.Range(count-1,1).
                         Aggregate(answer, (s,a)=> s += " AND " + a) ))+ "}";
    }
