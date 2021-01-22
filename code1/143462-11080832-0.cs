    public static int NthIndexOf(string text, char searchChar, int nthindex)
    {
       int index = -1;
       try
       {
          var takeCount = text.TakeWhile(x => (nthindex -= (x == searchChar ? 1 : 0)) > 0).Count();
          if (takeCount < text.Length) index = takeCount;
       }
       catch { }
       return index;
    }
    public static int NthIndexOf(string text, string searchText, int nthindex)
    {
         int index = -1;
         try
         {
            Match m = Regex.Match(text, "((" + searchText + ").*?){" + nthindex + "}");
            if (m.Success) index = m.Groups[2].Captures[nthindex - 1].Index;
         }
         catch { }
         return index;
    }
