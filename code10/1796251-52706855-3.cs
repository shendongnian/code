    public class ProductsController : FormatController
    {
      [Route("[controller]/[action]/{id}.{format?}")]
      public ActionResult GetById(int id)
      {
        var product = new { Id = id };
        return FormatOrView(product);
      }
    }
