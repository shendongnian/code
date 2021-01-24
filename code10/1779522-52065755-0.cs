    IList<Book> booksToRemove = new List<Book>() {
                                    new Book() { BookId = 1, BookName = "Rich Dad Poor Dad" };
                                    new Book() { BookId = 2, BookName = "The Great Gatsby" };
                                    new Book() { BookId = 3, BooktName = "The Kite Runner" };
                                };
    using (var context = new LibraryDBEntities()) {
    context.Books.RemoveRange(booksToRemove);
    context.SaveChanges(); }
