    public class UnitOfWork<T, CT> : IDisposable 
            where T : DbContext, new(){
        private readonly T context = new T();
        
        private DbRepository<PropType> _type;
    
        public DbRepository<PropType> Repository
        {
            get
            {
                return _type ?? (_type= new DbRepository<CT>(context);
            }
        }    
       
    } 
