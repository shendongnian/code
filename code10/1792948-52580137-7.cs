    public class MyController : Controller {
        private readonly IAzureTableConnection tableConnection;
    
        public MyController(IAzureTableConnection tableConnection) {
            this.tableConnection = tableConnection;
        }
    
        public async Task<IActionResult> MyAction() {
    
            //...
            HttpResponseMessage httpResponseMessage = await tableConnection.UpdateTenantSettings(post);
    
            //...
        }
    }
