    private static readonly HashSet<string> DiversionTypes = 
        new HashSet() { "DV", "DCV", "DVS" };
    private bool SentenceIsDiversion(DataRow r) { return (DiversionTypes.Contains(r.Field<string>("Type"))); }
    private bool SentenceIsDEJ(DataRow r) { return r.Field<string>("Type") == "DEJ"; }
    // Map charge disposition codes for diversion and DEJ to predicates that
    // test sentence rows for relevance.  Only sentences for charges whose disposition
    // code is in this map and who are described by the related predicate should be
    // updated.
    private static readonly Dictionary<string, Func<DataRow, bool>> DispoToPredicateMap =
        new Dictionary<string, Func<DataRow, bool>>
    {
       { "411211", SentenceIsDiversion },
       { "411212", SentenceIsDiversion },
       { "411213", SentenceIsDEJ },
       { "411214", SentenceIsDEJ },
    }
