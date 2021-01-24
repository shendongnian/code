    public class MyController : Controller {
       private readonly MyApiClient _client;
       public MyController() {
          _client = new MyApiClient();
       }
       public async Task<IActionResult> SomeAction() {
           await _client.Get();
           
           //... code removed for brevity
       }
    }
