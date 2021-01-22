    public IEnumerable<Book> Books //or public IList<Book> Books
    {
        get
        {
            if(this.books == null)
                throw new Exception("Books couldn't load because blah blah");
            return this.books;
        }
    }
