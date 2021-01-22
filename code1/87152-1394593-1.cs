    public class YourClass
    {
        private HttpContext _context;
        private string _itemKey;
        public YourClass()
        {
            _context = HttpContext.Current;
            if (_context == null) throw new InvalidOperationException("Boom!");
            _itemKey = "Key Goes Here";
        }
        public YourObject NonPersistentStatic
        {
            get { return (YourObject)(_context.Items[_itemKey]); }
            set { _context[_itemKey] = value; }
        }
    }
