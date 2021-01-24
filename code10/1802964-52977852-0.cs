    public class MyActionFilterAttribute: IActionFilter
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var id = actionContext.ActionArguments["Id"];
            if(string.IsNullOrEmpty(id))
                actionContext.Response = actionContext.Request.CreateResponse(
                HttpStatusCode.OK, 
                new {MESSAGE = "ID is required"}, 
                actionContext.ControllerContext.Configuration.Formatters.JsonFormatter
            );
        }
    }
    [HttpPost]
    [MyActionFilterAttribute]
    public ActionResult Post([FromQueryRequired] int? Id,[FromQuery] string Company)
