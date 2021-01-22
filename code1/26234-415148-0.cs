    people = new List<person>(){ new person { Name = "John", FamilyName = "Pendray" },
             new person { FamilyName = "Emery", Name = "Jake"},
             new person { FamilyName = "Pendray", Name = "Richard" } };
    var q = from p in people
            orderby p.Name
            group p by p.FamilyName into fam
            orderby fam.Key
            select new { Key = fam.Key, Text = GetText(fam) };
    // and elsewhere...
    private string GetText(IEnumerable<person> family) {
        string result = "Whatever"; // build the result string here
        return result;
    }
