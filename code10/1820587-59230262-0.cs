    public class Test 
    {
      private static readonly object _lockObject = new object();
      [HttpGet]
      public IActionResult MethodName
      {
           lock (_lockObject)
            {
              //TODO: your code here.
            }
      }
     }
