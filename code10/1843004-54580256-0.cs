    [Route("api/[controller]")]
    [ApiController]
    public abstract class ProductController<TProduct, TProductDTO> : ControllerBase
        where TProduct : Product, new()
        where TProductDTO : class, new()
    {
    }
    public class DownloadableController : ProductController<Downloadable, DownloadableDTO>
    {
    }
    public class ShippableController : ProductController<Shippable, ShippableDTO>
    {
    }
