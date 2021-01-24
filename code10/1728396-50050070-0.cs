    public class Book : IEquatable<Book>
    {
        public readonly string Title;
        public readonly string Author;
        public readonly string ISBN;
        public Book(string title, string author, string iSBN)
        {
            if (string.IsNullOrEmpty(title)) throw new ArgumentNullException(nameof(title));
            if (string.IsNullOrEmpty(author)) throw new ArgumentNullException(nameof(author));
            if (string.IsNullOrEmpty(iSBN)) throw new ArgumentNullException(nameof(iSBN));
            Title = title;
            Author = author;
            ISBN = iSBN;
        }
        public override bool Equals(Book other)
        {
            return other != null
                && other.Title == Title && other.Author == Author && other.ISBN == ISBN;
        }
        protected override bool Equals(object other)
        {
            if (!(other is Book)) return false;
            return Equals((Book)other);
        }
        public override int GetHashCode()
        {
            return Title.GetHashCode() ^ Author.GetHashCode() ^ ISBN.GetHashCode();
        }
    }
