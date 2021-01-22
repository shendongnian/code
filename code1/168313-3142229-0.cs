    public abstract class Repository<T> : IRepository<T>
    {
        public string Filename { get; private set; }
        public XmlLoader Loader { get; private set; }
    
        protected Repository<T>(HttpContextBase httpContext, XmlLoader loader, string relativePath)
        {
            Filename = httpContext.Server.MapPath(relativePath));
            Loader = loader;
        }
        public abstract IQueryable<T> GetAll();
    }
