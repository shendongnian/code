    public IActionResult Index(string q)
    {
        Func<Book, bool> searchFunc = (book) =>
        {
            string query = $"({q})";
            if (IsMatch(book.Title, query) || IsMatch(book.Author, query) || 
                IsMatch(book.ISBN, query))
            {
                return true;
            }
            return false;
        };
        var books = _bookstoreData.GetAll()
                                  .Where(searchFunc)
                                  .ToList();
        return books.Count > 0 ? View("SearchResult", books) : View(books);
    }
