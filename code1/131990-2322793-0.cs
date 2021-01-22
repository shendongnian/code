    public class BaseViewData
    {
      public string UserMessage { get; set; }
    }
    
    public class BaseController : Controller
    {
      protected override void OnResultExecuting(ResultExecutingContext filterContext)
      {
         ViewResult viewResult = filterContext.ActionResult as ViewResult;
         //Only continue if action returned an ActionResult of type ViewResult,
         //and that ViewResults ViewData is of type BaseViewData
         if(viewResult != null && viewResult.ViewData is BaseViewData)
         {
            ((BaseViewData)viewResult.ViewData).UserMessage = userService.GetUserMessage();
         }
      }
    }
