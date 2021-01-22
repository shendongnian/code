    public sealed class BookType
    {
        public static readonly BookType Novel = new BookType(1, 1, "Novel");
        public static readonly BookType Journal = new BookType(2, 2, "Journal");
        public static readonly BookType Reference = new BookType(3, 3, "Reference");
        public static readonly BookType Textbook = new BookType(4, 10, "Textbook");
        public int Low { get; private set; }
        public int High { get; private set; }
        private string name;
        private static class BookTypeLookup
        {
            public static readonly Dictionary<int, BookType> lookup = new Dictionary<int, BookType>();
        }
        private BookType(int low, int high, string name)
        {
            
            this.Low = low;
            this.High = high;
            this.name = name;
            for (int i = low; i <= high; i++)
                BookTypeLookup.lookup.Add(i, this);
        }
        public override string ToString()
        {
            return name;
        }
        public static implicit operator BookType(int value)
        {
            BookType result = null;
            if (BookTypeLookup.lookup.TryGetValue(value, out result))
                return result;
            throw new ArgumentOutOfRangeException("BookType not found");
        }
    }
