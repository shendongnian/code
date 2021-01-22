    public class YourClass
    {
        private readonly HttpContext _context;
        private readonly string _itemKey;
        public YourClass()
        {
            _context = HttpContext.Current;
            if (_context == null) throw new InvalidOperationException("Boom!");
            _itemKey = "Key Goes Here";
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
