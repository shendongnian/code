    public class XmlProductRepository : Repository<Product>
    {
        public XmlProductRepository(HttpContextBase httpContext, XmlLoader loader)
                 : base( httpContext, loader, "~/data/products.xml" ) {}
        public IQueryable<Product> GetAll()
        {
            return Loader.Load<ProductCollection>(Filename).AsQueryable();
        }
    }
