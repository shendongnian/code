        static void Main(string[] args)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>()
            {
                { "foo", "bar"},
                { "balloon", "red"}
            };
            Dictionary<string, string> dict2 = new Dictionary<string, string>()
            {
                { "fooey", "bar"},
                { "balloon", "red"}
            };
            var books = new List<Book>();
            books.Add(new Book("book1", dict));
            books.Add(new Book("book2", dict));
            books.Add(new Book("book1", dict));
            books.Add(new Book("book1", dict2));
            var distinctLib = RemoveDuplicateBooks(books);
        }
