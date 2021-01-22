    public class XmlRepository<TEntityType> : IRepository<TEntityType> 
    { 
    Type t = typeof(TEntityType);
    private const string RelativePath = String.Format("~/data/{0}.xml",t.Name); 
 
    public string Filename { get; private set; } 
    public XmlLoader Loader { get; private set; } 
 
    public XmlProductRepository(HttpContextBase httpContext, XmlLoader loader) 
    { 
        Filename = httpContext.Server.MapPath(RelativePath); 
        Loader = loader; 
    } 
 
    public IQueryable<TEntityType> GetAll() 
    { 
        return Loader.Load<List<TEntityType>>(Filename).AsQueryable(); 
    } 
} 
