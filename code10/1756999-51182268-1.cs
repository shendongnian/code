     // GET: api/Books
    [ResponseType(typeof(Book[]))]
    public IHttpActionResult GetBOOKS() {
        var books = db.BOOKS.OrderByDescending(x => x.BOOKID).Skip(977).Take(5)
        .Select(book => new Book {
            BookKId = book.BOOKID,
            BookName = book.BOOKNAME
            //...other properties
        })
        .ToArray();
        return Ok(books);
    }
