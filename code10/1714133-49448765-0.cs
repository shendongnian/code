    Gene[] GetThings(string subject, string chapter, ...)
    {
       var list = new List<Gene>();
       ... some code that populates list
       return list.ToArray();
    }
