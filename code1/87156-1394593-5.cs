    public class YourClass
    {
        private static readonly string _itemKey = "Key Goes Here";
        private readonly HttpContext _context;
        public YourClass()
        {
            _context = HttpContext.Current;
            if (_context == null) throw new InvalidOperationException("Boom!");
            // set a default value here if you like...
            if (_context.Items[_itemKey] == null)
            {
                _context.Items[_itemKey] = new YourType("Default Value");
            }
        }
        public YourType NonPersistentStatic
        {
            get { return (YourType)(_context.Items[_itemKey]); }
            set { _context.Items[_itemKey] = value; }
        }
    }
