    /// <summary>
    /// The BookCollection class is designed to work with lists of instances of Book.
    /// </summary>
    public class BookCollection : EntityCollectionBase<Book>
    {
        /// <summary>
        /// Initializes a new instance of the BookCollection class.
        /// </summary>
        public BookCollection()
        {
        }
        /// <summary>
        /// Initializes a new instance of the BookCollection class.
        /// </summary>
        public BookCollection (IList<Book> initialList)
            : base(initialList)
        {
        }
    }
