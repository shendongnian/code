    [Fact]
    public void CanCreateUser()
    {
        string bookName = DateTime.Now + "test book";
        var Book = new BookService(context);
        
        Data.Database.Entities.Book book = Book.AddNewBook(bookName);
        context.SaveChanges();
        book.Id.Should().NotBe(0);
        book.Name.Should().Be(bookName);
    }
