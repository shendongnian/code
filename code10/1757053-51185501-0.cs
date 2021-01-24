    using (MyDbContext db = new MyDbContext())
    {
        Book book = new Book();
        book.Title = textBox1.Text;
        book.Author = db.Find(this.author.Id);
    
        db.Books.Add(book);
        db.SaveChanges();
        this.Close();
    }
