    char[] delimiterChars = { ' ', ','};
    string[] searchterms = SearchBox.Split(delimiterChars);
    IQueryable<Book /* ? */> temp = _db.Books;
    foreach (string term in searchterms)
    { 
      temp = temp.Where(e => 
        (e.Title.Contains(term) || e.Author.Name.Contains(term));
    }
    IQueryable<SearchResult> = temp.Select(e => new SearchResult
    {
      Title = e.Title,
      Type = "Book",
      Link = "Book/" + e.BookID
    });
