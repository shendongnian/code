    var bookStore = new BookStore();
    bookStore.Books = new Dictionary<BookCategory, List<Book>>();
    var paragrapiaBooks = new List<Book>();
    paragrapiaBooks.Add(new Book{name = "Paragrapia book 1"});
    paragrapiaBooks.Add(new Book{name = "Paragrapia book 2"});
    bookStore.Books[BookCategory.Paragraphia] = paragrapiaBooks;
    var prismBooks = new List<Book>();
    prismBooks.Add(new Book{name = "Prism book 1"});
    prismBooks.Add(new Book{name = "Prism book 2"});
    bookStore.Books[BookCategory.Prism] = prismBooks;
    foreach (var bookCategory in bookStore.Books)
    {
        foreach (var book in bookCategory.Value)
        {
            Console.WriteLine(book.name);
        }
    }
    Console.ReadLine();
