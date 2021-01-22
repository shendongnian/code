    public class YourClass
    {
        private readonly HttpContext _context;
        private readonly object _itemKey;
        public YourClass()
        {
            _context = HttpContext.Current;
            if (_context == null) throw new InvalidOperationException("Boom!");
            _itemKey = new object();
        }
        public YourObject NonPersistentStatic
        {
            get { return (YourObject)(_context.Items[_itemKey]); }
            set { _context.Items[_itemKey] = value; }
        }
    }
