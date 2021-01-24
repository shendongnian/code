    public IEnumerable<IProduct> ReturnOnlyRequestedSkus(IEnumerable<IProduct> 
    products, IEnumerable<string> requestedSkus)
    {
      return products
        .Where(p => requestedSkus.Any(sku => String.Equals(p.Sku, sku, StringComparison.OrdinalIgnoreCase &&
           p.ItemType.Equals("Kit", StringComparison.OrdinalIgnoreCase) && 
           p.KitIncludes != null &&
           ...
           ;
    }
