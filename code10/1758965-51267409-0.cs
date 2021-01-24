    namespace YourNamespace.Controllers
    {
      [Route("[controller]/[action]")]
      public class YourController : Controller
      {
         private readonly IYourInterface _client;
         public YourController(IYourInterface client)
         {
             this._client = client;
         }
         [HttpPost]
         public async Task<JsonResult> GetYourDictionary(parms[] yourParms)
         {
             //Here is your dictionary
             var data = await _client.GetYourDictionary(yourParms);
             return Json(data);
         }
      }
    }
