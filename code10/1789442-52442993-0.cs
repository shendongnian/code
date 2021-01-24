    string[] cols = new string[] { "ColA", "ColB" };
    var rules = new List<Rule>
    {
        new Rule { TestId = 1, File = "Foo", Site = "SiteA", Columns = cols},
        new Rule { TestId = 1, File = "Foo", Site = "SiteB", Columns = cols}
    };
