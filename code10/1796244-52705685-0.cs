    [Route("[controller]")]
    [FormatFilter]
    public class ProductsController : Controller
    {
        private Product GetByIdCore(int id)
        {
            // common code here, return product
        }
        [HttpGet("[action]/{id}")]
        [ActionName("GetById")]
        public IActionResult GetByIdView(int id) => View(GetByIdCore(id));
        [HttpGet("[action]/{id}.{format}")]
        public Product GetById(int id) => GetByIdCore(id);
    }
