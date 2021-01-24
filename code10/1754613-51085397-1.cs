    public class Person
    {
        private readonly ILogger _logger;
        public Person() { } // normal public constructor
    
        private Person(MyDbContext db) // private constructor that EF will invoke
        {
            _logger = db.LoggerFactory?.CreateLogger<Person>();
        }
        public bool HasCat()
        {
            _logger?.LogTrace("Check has cat");
            return true;
        }
    }
