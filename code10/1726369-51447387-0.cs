    QueryParsers.Classic.MultiFieldQueryParser oPhraseParser = new QueryParsers.Classic.MultiFieldQueryParser(Version, FieldArray, Analyzer, BoostDictionary);
    List<PhraseQuery> lstPhraseQuery = new List<PhraseQuery>();
    HashSet<Term> lstTerms = new HashSet<Term>();
    oPhraseParser.Parse(pQuery).ExtractTerms(lstTerms);
    foreach (var group in lstTerms.GroupBy(x => x.Field))
    {
        PhraseQuery oPhraseQuery = new PhraseQuery() { Boost = 10, Slop = 3 };
        foreach (var oTerm in group.ToList())
        {
            oPhraseQuery.Add(oTerm);
            if (oTerm.Field == Field.ImportantField)
                oPhraseQuery.Boost = 30;
        }
        lstPhraseQuery.Add(oPhraseQuery);
    }
    return lstPhraseQuery;
