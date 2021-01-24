    public class MyController : Controller {
        private static readonly MyApiClient _apiClient = new MyApiClient ();
    
        public async Task<ActionResult> ApiTest() {
            var data = await _apiClient.GetSomeData();
    
            //...
        }
    }
