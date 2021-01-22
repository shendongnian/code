    public static List<string> SearchListWithSearchPhrase
        (List<string> tasks, string searchPhrase)
    {
        IEnumerable<string> searchTerms = searchPhrase.Split(' ')
                                                      .Select(x => x.Trim());
        IEnumerable<string> query = tasks;
        foreach (string term in searchTerms)
        {
            query = query.Where(t => t.ToUpper().Contains(term));
        }
        return query.ToList();
    }
