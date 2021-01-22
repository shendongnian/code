    public enum BookType
    {
        Novel = 1,
        Journal = 2,
        Reference = 3,
        TextBook = 4
    }
    
    public void bookOutput(int book)
    {
       if(book < 4)
           Console.Writeline("Book "+book+" is a " + ((BookType)book).ToString());
       else
           Console.Writeline("Book "+book+" is a " + BookType.TextBook.ToString());
    }
