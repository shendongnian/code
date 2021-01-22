    public List<string> RemoveDuplicates(List<string> listWithDups)
    {
       cleanList = new List<string>();
       foreach (string s in listWithDups)
       {
          if (!cleanList.Contains(s))
             cleanList.Add(s);
       }
       return cleanList;
    }
