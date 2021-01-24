    [Produces("application/json")]
    public class YourController: Controller {
       [HttpGet]
       public IEnumerable<string> Get()
       {
           return new string[] { "value1", "value2" };
       }
    }
