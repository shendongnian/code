    public IEnumerable<SelectListItem> GetAllLookupKey()
    {
        return _context.ProductType.Select( pt=>new SelectListItem
        {
            Value = pt.ProductTypeName,
            Text = pt.ProductDescription
        }).ToList();
    }
