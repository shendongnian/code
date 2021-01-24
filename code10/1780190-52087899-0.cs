    public class InstallService : IService
    {
        private SQLContext _context;
        public InstallService(SQLContext context) 
        {
            _context = context;
        }  
    }
