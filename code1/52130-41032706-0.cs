    public BookList Find(string key)
    {
       BookList book; //BookList is a model class
       _books.TryGetValue(key, out book) //_books is a concurrent dictionary
                                         //TryGetValue gets an item with matching key and returns it into book.
       return book;
    }
