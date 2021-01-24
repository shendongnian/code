    public sealed class FramesController : ApiController {
        private readonly IProductService prodSvc;
        public FramesController(IProductService _prodSvc) {
            prodSvc = _prodSvc;
        }
        public IHttpActionResult GetFrames(int productTypeId) {
            var products = prodSvc.GetProductsByCategoryId((int)Enums.CategoryGroup.Frame, productTypeId);
            if(!products.Any())
                return NotFound();
            var result = new { frames = products.ToArray() };
            return Ok(result);
        }
    }
