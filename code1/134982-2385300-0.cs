    textQuery.SetProjection(ProjectionConstants.SCORE, ProjectionConstants.THIS);
    var list = textQuery.List();
    var books = new List<Book>();
    foreach(object[] o in list)
    {
        var book= o[1] as Book;
        if (book!= null)
        {
            book.Score = (float)o[0];
        }
        books.Add(book);
    }
    return books;
