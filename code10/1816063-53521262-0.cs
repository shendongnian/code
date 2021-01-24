    namespace CTB_APP.Controllers.API.Delete
    {
    [RoutePrefix("api/test/")]
    public class TestController : ApiController
    {
        [Route("name/{param}")]
        public string Get(string param)
        {
        return param + 1;
        }
  
       [Route("age/{param}")]
       public int Get(int param)
       {
          return param + 1;
       }
     }
    }
