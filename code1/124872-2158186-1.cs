    public IEnumerable<string> SomeList
    {
       get
       {
          foreach(string s in someList) yield return s; // excuse my inline style here, zealots
          yield break;
       }
    }
