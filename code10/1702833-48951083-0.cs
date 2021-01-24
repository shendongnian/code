    [RoutePrefix("Products")]
    public class ProductsController : ApiController
    {
        private readonly Product[] m_products = {
            new Product {Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1},
            new Product {Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M},
            new Product {Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M}
        };
        public IEnumerable<Product> GetAllProducts()
        {
            return this.m_products;
        }
        [HttpGet]
        [Route("ById/{id:int}")]
        public IHttpActionResult GetProductById(int id)
        {
            var product = this.m_products.FirstOrDefault(x => x.Id == id);
            return product == null ? (IHttpActionResult) NotFound() : Ok(product);
        }
        [HttpGet]
        [Route("ByName/{name}")]
        public IHttpActionResult GetProductByName(string name)
        {
            var product = this.m_products.FirstOrDefault(x => x.Name == name);
            return product == null ? (IHttpActionResult) NotFound() : Ok(product);
        }
    }
