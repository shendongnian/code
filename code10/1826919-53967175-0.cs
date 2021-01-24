    public class WatchedProduct : ApiController
    {
     // GET: api/WatchedProduct
     [HttpGet]
      [Route("WatchedProduct")]
       public IEnumerable<WatchedProduct> Get()
      {
       var context = Request.Properties["MS_HttpContext"] as HttpContext;
       var id = context.Request.QueryString["id"];
        var productsList = id == String.Empty ?
        db.WatchedProducts.Where(u => u.ApplicationUserId == id).ToList() :
        db.WatchedProducts.Where(u => u.ApplicationUserId == loggedUserId).ToList();
        return productsList;
      }
    }
