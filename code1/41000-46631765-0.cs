    public class DataContextProxy : IDataContext
    {
        private readonly DataContext _context;
        public DataContextProxy(DataContext context)
        {
            _context = context;
        }
        // Snipped irrelevant code
        public IOrderedQueryable<T> Randomize<T>(IQueryable<T> query)
        {
            return query.OrderBy(x => _context.Random());
        }
    }
