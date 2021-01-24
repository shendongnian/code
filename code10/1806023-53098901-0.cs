    public class Book
    {
        private string _name;
        private string _author;
        private string _genre;
        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }
        public string Genre
        {
            get { return _genre; }
            set { _genre = value; }
        }
        
        public string GetValue( Criteria criteria)
        {
            switch (criteria)
            {
                case Criteria.Author:
                    return _name;                    
                case Criteria.Genre:
                    return _genre;                    
                case Criteria.Name:
                    return _name;
                default:
                    return string.Empty;
            }
        }
    }
    public enum Criteria
    {
        Name,
        Author,
        Genre
    }
