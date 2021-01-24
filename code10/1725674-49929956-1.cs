    [TestCase("9783161484100", "Some Name", "C# in a nutshell", "Orelly", 2014, (ushort)900, 60, ExpectedResult = "Some Name Orelly")]
    [Test]
    public string FormatBook_FortmattingBooksObject_IsCorrectString(string isbn, string author, string title, string publisher, int year, ushort pages, decimal price)
    {
        INinjectModule module = ...;//Create a module and add the ILogger here
        using (IKernel kernel = new StandardKernel(module))
        {
            var fakeLogger = kernel.Get<ILogger>(); //Get the logger  
            var book = new Book(isbn, author, title, publisher, year, pages, price, fakeLogger); 
            Console.WriteLine(book.FormatBook(book.Author, book.Publisher));
            return book.FormatBook(book.Author, book.Publisher);
        }
    }
