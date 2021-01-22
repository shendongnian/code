    class Product {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category {get; set; }
        public int Quantity { get; set; }
        public decimal RetailPrice { get; set; }
    }
    IList<Product> products = new List<Product>();
    for (int i=0; i < _productId.Length; i++) {
        products[i] = new Product {
            Id = _productId[i],
            Name = i < _productName.Length ? _productName[i] : null,
            Category = i < _prodCat.Length ? _prodCat[i] : null,
            Quantity= i < _quantity.Length ? int.Parse(_quantity[i]) : 0 // etc
        };
    }
    
    // Then use normal Linq2Objects:
    _products = products
        .Where(c => !string.IsNullOrEmpty(c.Category))
        .Where(n => !string.IsNullOrEmpty(n.Name))
        .Select(x => x.Id);
    _products.Dump("Products")
