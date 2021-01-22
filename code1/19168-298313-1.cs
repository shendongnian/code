    public IEnumerable<ProdPriceDisplay> GetShopProductsPrices()
    {
        var products = from shop in db.SHOPs
                       select new ProdPriceDisplay
                       {
                           ProdPrice = shop.S_NAME + " - £" + shop.S_PRICE
                       };
        return products.AsEnumerable()
                       .Concat(new [] { new ProdPriceDisplay 
                               { ProdPrice = "some additional text"; });
    }
