    Product[] products = GetProducts();
    
    CacheManager cache = CacheFactory.GetCacheManager();
    
    AbsoluteTime twentyFourHoursLater = new AbsoluteTime(DateTime.Now.AddHours(24));
    SlidingTime oneMinuteSlidingTime = new SlidingTime(TimeSpan.FromMinutes(1));
    
    foreach (Product product in products)
    {
        if (product.ProductPrice < 100)
        {
            cache.Add(product.ProductID, product, CacheItemPriority.Normal, null,
                twentyFourHoursLater);
        }
        else
        {
            cache.Add(product.ProductID, product, CacheItemPriority.Normal, null,
                oneMinuteSlidingTime);
        }
    }
