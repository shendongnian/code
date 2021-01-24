    public class ValuesController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult Get()
        {
            var actionName = this.ActionContext.ActionDescriptor.ActionName;
            var controlerName = this.ControllerContext.ControllerDescriptor.ControllerName;
            return this.Ok();
        }
    }
