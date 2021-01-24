        class ProductCategory
        {
            string ProductName { get; set; }
            string CategoryName { get; set; }
        }
        private void test()
        {
            var joined = _context.Products.Join(_context.Categories, p => p.CategoryId, c => c.CategoryId, (product, category) => new ProductCategory
            {
                ProductName = product.Name,
                CategoryName = category.Name
            });
        }
