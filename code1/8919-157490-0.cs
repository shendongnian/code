    /// <summary>
    /// This is a Book
    /// </summary>
    interface IBook
    {
        string Title { get; }
        string ISBN { get; }
    }
    /// <summary>
    /// This is a Person
    /// </summary>
    interface IPerson
    {
        string Title { get; }
        string Forename { get; }
        string Surname { get; }
    }
    /// <summary>
    /// This is some freaky book-person.
    /// </summary>
    class Class1 : IBook, IPerson
    {
        /// <summary>
        /// This method is shared by both Book and Person
        /// </summary>
        public string Title
        {
            get
            {
                string personTitle = "Mr";
                string bookTitle = "The Hitchhikers Guide to the Galaxy";
                // What do we do here?
                return null;
            }
        }
        #region IPerson Members
        public string Forename
        {
            get { return "Lee"; }
        }
        public string Surname
        {
            get { return "Oades"; }
        }
        #endregion
        #region IBook Members
        public string ISBN
        {
            get { return "1-904048-46-3"; }
        }
        #endregion
    }
