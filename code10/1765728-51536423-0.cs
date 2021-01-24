    public IActionResult LSProducts()
    {
       List<ProductSoldViewModel> model = new List<ProductSoldViewModel>();
    
       model = _context.Product
                .Include(a => a.OrderDetail)
                .Select(o => new ProductSoldViewModel
                {
                    ProductCode = o.CodProduct,
                    ProductName = o.Nome,
                    Qty = o.OrderDetail.Sum(s => s.Qty)
                })
             .OrderBy(od => od.Qty)
             .ToList();
    
       return View(model);
    }
