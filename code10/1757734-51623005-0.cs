    public class MyController : Controller
    {
       [HttpPost]
       public async Task<IActionResult> SomeEndpoint([FromBody]Payload inPayload)
       {
       ...
       }
    }
    
    public class Payload
    {
       public string SomeString { get; set; }
       public int SomeInt { get; set; }
    }
