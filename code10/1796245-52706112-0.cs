    [FormatFilter]
    public class ProductsController
    {
        [Route("[controller]/[action]/{id}.{format?}")]
        public Product GetById(int id, string format)
        {
            var yourModel = ...;
            if (string.IsNullOrWhiteSpace(format))
                return View(yourModel);
            return Ok(yourModel);
        }
