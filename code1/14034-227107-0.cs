    public static bool CaselessIs(this string s, IEnumerable<string> compareTo)
    {
       foreach(string comparison in compareTo)
       {
          if (Extensions.CaselessIs(s, comparison))
          {
             return true;
          }
       }
       return false;
    }
