    public static List<string> SearchListWithSearchPhrase
        (List<string> tasks, string searchPhrase)
    {
        IEnumerable<string> searchTerms = searchPhrase.Split(' ')
                                                      .Select(x => x.Trim());
        IEnumerable<string> query = tasks;
        foreach (string term in searchTerms)
        {
            String captured = term;
            query = query.Where(t => t.ToUpper().Contains(captured));
        }
        return query.ToList();
    }
