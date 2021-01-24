    public class Writer<T> where T:class
    {
        private DbContext _context;
        public Writer(DbContext context)
        {
            _context = context;
        }
        public void Insert(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }
    }
