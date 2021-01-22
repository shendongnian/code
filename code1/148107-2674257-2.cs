    List<string> Entries = new List<string>();
    Entries.Add("foo");
    Entries.Add("bar");
    Entries.Add("@foo");
    Entries.Add("1bar");
    var NonAlphas = (from n in Entries
    where !char.IsLetter(n.ToCharArray().First())
    select n);
