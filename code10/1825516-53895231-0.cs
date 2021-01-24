    public IActionResult OnGetSellProduct(int id)
    {
        var products = _context.Products;
        _context.Products.Find(id).SubtractProduct();
        return Page();
    }
