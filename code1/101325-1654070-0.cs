    public class PermanentRedirectResult : ActionResult
    {
      private string _url;
      public PermanentRedirectResult(string url)
      {
        _url = url;
      }
      public override void ExecuteResult(ControllerContext context)
      {
          context.HttpContext.Response.StatusCode = 301;
          context.HttpContext.Response.RedirectLocation = _url;
      }
    }
