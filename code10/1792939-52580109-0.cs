    public class SomeController : Controller
    {
        private readonly AzureTableConn _azureTableConn;
        public SomeController(AzureTableConn azureTableConn)
        {
            _azureTableConn = azureTableConn;
        }
    }
