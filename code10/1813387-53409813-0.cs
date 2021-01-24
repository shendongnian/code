    public class YourController : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            try
            {
                //do your session check here...
                //alternatively, if you wanted to limit to certain actions in your controller you could say: 
                var actionName = requestContext.RouteData.Values["action"].ToString().ToLower();
                if(actionName == "actionName" || actionName == "actionName2") {
                   //do your limited session work...
                }
            }
            catch (Exception e) { }
        }
        ...
