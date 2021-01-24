    public class ProductsController : ApiController {
        List<Product> productList = new List<Product>();
        public ProductsController() {
            this.productList.Add(new Product { Id = 111, Name = "sandeep 1" });
            this.productList.Add(new Product { Id = 112, Name = "sandeep 2" });
            this.productList.Add(new Product { Id = 113, Name = "sandeep 3" });
        }
        //Matched GET api/products
        [HttpGet]
        public IHttpActionResult Get() {
            return Ok(productList);
        }
        //Matched GET api/products/111
        [HttpGet]
        public IHttpActionResult Get(int id) {
            var product = productList.FirstOrDefault(p => p.Id == id));
            if(product == null)
                return NotFound();
            return Ok(product); 
        }
    }
