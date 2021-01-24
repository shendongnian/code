    public IActionResult LSProducts()
    {
       List<ProductSoldViewModel> model = new List<ProductSoldViewModel>();
    
       model = _context.Product
                .Include(a => a.OrderDetails)
                .Select(o => new ProductSoldViewModel
                {
                    ProductCode = o.CodProduct,
                    ProductName = o.Nome,
                    Qty = o.OrderDetails.Sum(s => s.Qty)
                })
             .OrderBy(od => od.Qty)
             .ToList();
    
       return View(model);
    }
