    private void GridView_AddBook(Book book)
    {
        Book b = new Book
        {
            Title = book.title,
            Author = book.author,
            Publisher = book.publisher,
            ISBN = book.isbn,
            Quantity = book.quantity.GetValueOrDefault(),
            CoverImageLocation = book.CoverImageUri
        };
        ViewModel.Books.Add(b);
    }
