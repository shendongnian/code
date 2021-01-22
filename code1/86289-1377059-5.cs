    public static IEnumerable<Record> ReadRecords(string path)
    {
        IEnumerable<Regex> expresssions = new List<Regex>
        {
            new Regex( @"No.(?P<Number>[\d]{9}) +((?P<Date>[\d]{2}/[\d]{2}/[\d]{4}) +)?(?P<Code>.*)" ),
            new Regex( @"NCL\([\d]{1}\) (?P<Ncl>[\d]{2})( (?P<Especification>"), 
            new Regex( @"C.N.P.J./C.I.C./NºINPI : (?P<Document>.*)")
        };
        foreach ( MatchCollection matches 
            in ReadLines(path)
              .Select(s => expressions.First(e => e.IsMatch(s)).Matches(s)))
              .Where(m => m.Count > 0) 
        )                       
        {
            yield return Record.FromExpressionMatches(matches);
        }
    }
