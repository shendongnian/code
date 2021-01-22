    [Serializable]
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        // Constructor for setting new values. 
        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }
