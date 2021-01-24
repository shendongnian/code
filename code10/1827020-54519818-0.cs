    public class CatalogServiceContext : DbContext
    {
        public ICurrentUser CurrentUser;
		
        [Obsolete("Use CatalogServiceContextUserWrapper instead")]
        public CatalogServiceContext() : base("name=CatalogContext")
        {
        }
		
		...
		
		
	public class CatalogServiceContextUserWrapper
    {
        public CatalogServiceContext Context;
        public CatalogServiceContextUserWrapper(CatalogServiceContext context, ICurrentUser currentUser)
        {
            context.CurrentUser = currentUser;
            this.Context = context;
        }
    }
