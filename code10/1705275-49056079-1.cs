    /// <summary>
    /// The information about a book which is included with an Author
    /// </summary>
    class AuthorBookInfo
    {
        // to get the full Book object if needed
        public string Id; 
        // Extra information about the relation (join table)
        public AuthorRole Role; // Editor, Author, Contributor, etc.
        // Now extra information from book to reduce the need to retrieve the book object
        public string Title;
        public string ISBN;
        public DateTime PublicationDate;
    }
    class Author {
        public string Id;
        public string Name;
        public List<AuthorBookInfo> Books;
        public DateTime DateOfBirth;
        public string ShortBiography;
    
    }
    class AuthorInfo
    {
        public string Id;
        public string Name;
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
