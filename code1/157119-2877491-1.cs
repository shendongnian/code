    class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
    class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class BookTag
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int TagId { get; set; }
    }
...
    Book book1 = new Book() { Id = 113421, Title = "A" };
    Book book2 = new Book() { Id = 113422, Title = "B" };
    Tag tag1 = new Tag() { Id = 1, Name = "ASP" };
    Tag tag2 = new Tag() { Id = 2, Name = "C#" };
    BookTag bookTag1 = new BookTag() { Id = 1, BookId = 113421, TagId = 1 };
    BookTag bookTag2 = new BookTag() { Id = 2, BookId = 113421, TagId = 2 };
    BookTag bookTag3 = new BookTag() { Id = 3, BookId = 113422, TagId = 1 };
    List<Book> books = new List<Book>() { book1, book2 };
    List<Tag> tags = new List<Tag>() { tag1, tag2 }; // not really used in this sample
    List<BookTag> booktags = new List<BookTag>() { bookTag1, bookTag2, bookTag3 };
    List<int> selectedTagIds = new List<int>() { 1, 2 };
    var query = from book in books
                join booktag in booktags 
                on book.Id equals booktag.BookId 
                join selectedId in selectedTagIds 
                on booktag.TagId equals selectedId 
                group book by book into bookgroup 
                where bookgroup.Count() == selectedTagIds.Count
                select bookgroup.Key;
    foreach (Book book in query)
        Console.WriteLine(book.Title);
