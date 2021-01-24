    static void Main(string[] args)
    {
        string spokenWord = "accounts";
        HashSet<string> search = new HashSet<string>(); //tokenize the search keywords and store in dictionary...
        for (int z = 0; z < 1; z++)
        {
            for (int inner = 1; inner <= spokenWord.Length - z; inner++)
            {
                // by default orders in order of increasing length of substring
                search.Add(spokenWord.Substring(z, inner));
            }
        }
        // for loop above wrtten usnig linq....however in this case I think for loops wins becuase of greater clarity
        //var items = Enumerable.Range(0, 1).SelectMany(x => Enumerable.Range(1, spokenWord.Length - x).Select(j => spokenWord.Substring(x, j)));
        List<Match> matches = new List<Match>();
        matches.Add(new Match { Rank = 1, Name = "dev" });
        matches.Add(new Match { Rank = 1, Name = "finance" });
        matches.Add(new Match { Rank = 1, Name = "accounts" });
        matches.Add(new Match { Rank = 1, Name = "abcounts" });
        // ordering using rank and new searchrank score
        foreach (var match in matches.Select(m => new { Name = m.Name, Rank = m.Rank, SearchRank = MatchRank(search, m.Name) }).OrderBy(x => x.Rank).ThenByDescending(x => x.SearchRank))
        {
            Console.WriteLine(String.Format("Name: {0}, Rank: {1}", match.Name, match.Rank));
        }
    }
