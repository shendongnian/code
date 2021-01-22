    public class AdminRepository<T> : Repository<T> where T: class
    {
        static AdminDataContext dc = new AdminDataContext(System.Configuration.ConfigurationManager.ConnectionStrings["MY_ConnectionString"].ConnectionString);
    
        public AdminRepository()
            : base( dc )
        {
        }
