     IJwtHelper jwtHelper = ...;
     // The product database: all functionality to do everything with Products and Orders
     ProductDbContext dbContext = new ProductDbContext(...)
     {
        JwtHelper = jwtHelper,
        ...
     };
     // The Ordering repository: everything to place Orders,
     // It can't change ProductPrices, nor can it stock the wharehouse
     // So no AddProduct, not AddProductCount,
     // of course it has TakeNrOfProducts, to decrease Stock of ordered Products
     OrderingRepository repository = new OrderingRepository(...) {DbContext = dbContext};
     // The ordering process: Create Order, find Order, ...
     // when an order is created, it checks if items are in stock
     // the prices of the items, if the Customer exists, etc.
     using (OrderingProcess process = new OrderingProcess(...) {Repository = repository})
    {
         ... // check if Customer exists, check if all items in stock, create the Order
         process.SaveChanges();
    }
