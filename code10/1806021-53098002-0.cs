    public static string GetValue(string propertyName)
    {
        Book book = new Book();
        book.Name = "A";
        book.Author = "B";
        book.Genre = "C";
        return book.GetType().GetProperty(propertyName).GetValue(book, null).ToString();
        //Don't foget to handle exception
    }
