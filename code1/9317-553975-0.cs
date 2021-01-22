    IEnumerable<string> GetTheStuff()
    {
        List<string> s = null;
        if (somePredicate())
        {
            var stuff = new List<string>();
            // load data
            return stuff;
        }
        return Enumerable.Empty<string>();
    }
