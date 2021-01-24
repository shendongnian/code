    public class GenericRepository<T> : IGenericRepository<T> where T : class  
    {
        public GenericRepository(IDbFactory dbFactory)  
        {  
            DbContext = new Lazy<DBCustomerEntities>(dbFactory.Init);
        } 
    
   
        private Lazy<DBCustomerEntities> DbContext { get; }
    
        protected DBCustomerEntities DbContext => _DbContext.Value;
    
        public IQueryable<T> GetAll() => DbContext.Value.Set<T>();
        .......
