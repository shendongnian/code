    public IEnumerable<string> SomeList
    {
       get
       {
          foreach(string s in SomeList) yield return s; // excuse my inline style here, zealots
          yield break;
       }
    }
