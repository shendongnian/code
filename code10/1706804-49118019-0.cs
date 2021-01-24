    public class FooController : Controller
    {
        private ConnectionStringsConfig _connectionStrings;
        public FooController(IOptionsSnapshot<ConnectionStringsConfig> connectionStrings)
        {
            _connectionStrings = connectionStrings?.Value ?? throw new ArgumentNullException(nameof(connectionStrings));
        }
    }
