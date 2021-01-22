    IEnumerable<string> GetStrings(IEnumerable<List<string>> lists)
    {
       foreach (List<string> list in lists)
       foreach (string item in list)
       {
         yield return item;
       }
     }
       
