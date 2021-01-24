    public class GenericRepository<T> : IGenericRepository<T> where T : class  
    {
        public GenericRepository(IDbFactory dbFactory)  
        {  
            DbContext = new Lazy<DBCustomerEntities>(dbFactory.Init);
        } 
    
   
        protected Lazy<DBCustomerEntities> DbContext { get; }
    
        public IQueryable<T> GetAll() => DbContext.Value.Set<T>();
        .......
