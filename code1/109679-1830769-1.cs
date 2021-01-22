    char[] delimiterChars = { ' ', ','};
    string[] searchterms = SearchBox.Split(delimiterChars);
    var temp = _db.Books;
    foreach (string term in searchterms)
    { 
      temp = temp.Where(e => 
        (e.Title.Contains(term) || e.Author.Name.Contains(term));
    }
    IQueryable<SearchResult> results = temp.Select(e => new SearchResult
    {
      Title = e.Title,
      Type = "Book",
      Link = "Book/" + e.BookID
    });
