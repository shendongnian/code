    public class UnitOfWork : IDisposable
    {
        // Remember that SchoolContext must implement ISchoolContext
        private SchoolContext _context;
        
        public UnitOfWork(ISchoolContext context) 
        {
            _context = context;
        }    
    }
