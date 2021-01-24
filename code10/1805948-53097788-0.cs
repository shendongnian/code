    libraries.GroupBy(x=>x.Books.Select(s=>s.BookID), new BookIdsComparer ())
    public class BookIdsComparer : IEqualityComparer<IEnumerable<string>>
    {
        public bool Equals(IEnumerable<string> bookIds1, IEnumerable<string> bookIds2)
        {
            return bookIds1.Count() == bookIds2.Count() 
                && bookIds1.Intersect(bookIds2).Count() == bookIds1.Count();
        }
        public int GetHashCode(IEnumerable<string> bookIds)
        {
            var result = 1;
            foreach (var bookId in bookIds)
            {
                result ^= bookId.GetHashCode();
            }
            return result;
        }
    }
