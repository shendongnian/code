        // POST api/<controller>
        public void Post([FromUri]Book book)
        {
            db.Books.Add(new Book()
            {
                BookName = book.BookName
            });
            db.SaveChanges();
        }
