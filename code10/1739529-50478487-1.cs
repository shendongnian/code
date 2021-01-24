    public class UnitOfWork : IDisposable
    {
        private ISchoolContext _context;
        
        public UnitOfWork(ISchoolContext context) 
        {
            _context = context;
        }    
    }
