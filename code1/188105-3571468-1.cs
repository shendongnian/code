    protected IEnumerable<string> GetNames(Family fam)
    {
      foreach(Person p in fam.Members)
        yield return p.FirstName + " " + p.Surname;
    }
    protected IEnumerable<string> GetNames(object famObj)
    {
        return GetNames((Family)famObj;
    }
