    // GET: api/WatchedProduct
    [HttpGet]
    [Route("WatchedProduct")]
    public IEnumerable<WatchedProduct> GetWatchedProduct(string id)
    {
        var productsList = id == String.Empty ?
            db.WatchedProducts.Where(u => u.ApplicationUserId == id).ToList() :
            db.WatchedProducts.Where(u => u.ApplicationUserId == loggedUserId).ToList();
        return productsList;
    }
