    [Produces("application/json")]
    [Route("api/Rule/[action]")]
    public class RuleController : Controller
    {
       [HttpPost]
       public Task<IActionResult> AddTemplateTextRules( [FromBody]Rule[] Rules)
       {
           try
           {
               return RuleManager.AddRule(Rules);
           }
           catch (Exception e)
           {
                return false;
           }
           return Json(true);
       }
    }
 
