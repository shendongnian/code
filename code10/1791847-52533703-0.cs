    public class DataBaseLayer
    {
        private readonly string _connectionString;
        private readonly string _userName;
        private readonly ILogger _logger;
        private readonly ITypeMapper _mapper;
        public DataBaseLayer(
            string connectionString,
            string userName,
            ILogger logger,
            ITypeMapper mapper)
        {
            _connectionString = connectionString;
            _userName = userName;
            _logger = logger;
            _mapper = mapper;
        }
    }
    public interface ITypeMapper
    {
    }
    public class TypeMapper : ITypeMapper
    {
    }
    public interface ILogger
    {
        
    }
    public class Logger : ILogger
    {
        
    }
