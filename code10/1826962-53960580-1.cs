    public ActionResult CreateNewBook(BooksContainer books)
    {
        var book = new Book()
        {
            ID = new Random().Next(3, 999_999),
        };
        books.Book.Add(book);
        return View(books);
    }
