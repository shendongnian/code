    [Route("api/[controller]")
    public class SomeController
    {
      [HttpGet]
      [Route("id/{id}")]
      public someGetMethod(int id){
        //do something with id here...
      }
    }
