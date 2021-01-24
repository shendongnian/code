    public class WatchedProduct : ApiController
    {
        // GET: api/WatchedProduct
        [HttpGet]
        public IEnumerable<WatchedProduct> Get(string id)
        {
            var productsList = id == String.Empty ?
            db.WatchedProducts.Where(u => u.ApplicationUserId == id).ToList() :
            db.WatchedProducts.Where(u => u.ApplicationUserId == loggedUserId).ToList();
            return productsList;
        }
    }
