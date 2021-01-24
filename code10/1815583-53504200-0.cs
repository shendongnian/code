    private static IList<SelectListItem> GetComponents()
        {
            XDbContext _context = new XDbContext();
            var query = _context.Components.AsQueryable();
            return (query.ToList())
                .Select(d => new SelectListItem { Text = d.Name, Value = d.Id.ToString() })
                .ToList();
        }
        private static IList<SelectListItem> myComponents;
        public static IList<SelectListItem> ComponentList
        {
            get
            {
                return myComponents;
            }
        }
