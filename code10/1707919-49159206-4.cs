    public class UnitOfWork<T, CT> : IDisposable 
            where T : DbContext, new(){
        private readonly T context = new T();
        
        private DbRepository<CT> _type;
    
        public DbRepository<CT> Repository
        {
            get
            {
                return _type ?? (_type= new DbRepository<CT>(context);
            }
        }    
       
    } 
