    public class MyRepositoryFactory : IRepositoryFactory
    {
        private readonly HttpContextBase httpContext;
        public MyRepositoryFactory(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }
            this.httpContext = httpContext;
        }
        #region IRepositoryFactory Members
        public Repository Create()
        {
            // return Repository created from this.httpContext
        }
        #endregion
    }
