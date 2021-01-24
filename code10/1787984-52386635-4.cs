    public class ClassName
    {
        private readonly IConnectionStringFactory _connectionStringFactory;
   
    public ClassName(IConnectionStringFactory connectionStringFactory)
        {
            _connectionStringFactory = connectionStringFactory;
        }
    
    ...
    }
