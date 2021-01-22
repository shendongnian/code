        [SqlFunction(DataAccess = DataAccessKind.Read, FillRowMethodName = "FillMatches", TableDefinition = "GroupNumber int, MatchText nvarchar(4000)")]
    public static IEnumerable Findall(string Pattern, string Input)
    {
        List<RegexMatch> GroupCollection = new List<RegexMatch>();
        Regex regex = new Regex(Pattern);
        if (regex.Match(Input).Success)
        {
            int i = 0;
            foreach (Match match in regex.Matches(Input))
            {
                GroupCollection.Add(new RegexMatch(i, match.Groups[0].Value));
                i++;
            }
        }
        return GroupCollection;
    }
