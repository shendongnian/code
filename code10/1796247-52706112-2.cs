    [FormatFilter]
    public class ProductsController : Controller
    {
        [Route("[controller]/[action]/{id}.{format?}")]
        public IActionResult GetById(int id, string format)
        {
            var yourModel = ...;
            if (string.IsNullOrWhiteSpace(format))
                return View(yourModel);
            return Ok(yourModel);
        }
