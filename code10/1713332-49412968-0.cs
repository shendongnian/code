    var dict = new Dictionary<string, List<Publication>>();
    foreach (var publication in list)
    {
        foreach (var author in publication.Authors)
        {
            if (!dict.ContainsKey(author))
                dict.Add(author, new List<Publication>());
            dict[author].Add(publication);
        }
    }
