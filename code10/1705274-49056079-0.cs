    class AuthorInfo
    {
        public string Id;
        public string Name;
    }
    /// <summary>
    /// The information about a book which is included with an Author
    /// </summary>
    class AuthorBookInfo
    {
        public string Id; // to get the full Book object if needed
        public string Title;
        public string ISBN;
        public DateTime PublicationDate;
        public AuthorRole Role; // Editor, Author, Contributor, etc.
    }
    class Author {
        public string Id;
        public string Name;
        public List<AuthorBookInfo> Books;
        public DateTime DateOfBirth;
        public string ShortBiography;
    
    }
    class Book {
        public string Id; // to get the full Book object if needed
        public string Title;
        public string ISBN;
        public DateTime PublicationDate;
        public List<AuthorInfo> Authors;
        public PublisherInfo Publisher;
        public string PublicationLanguage;
        public List<BookInfo> Translations;
    }
