    public class PermanentRedirectResult : ActionResult
    {
      public string Url;
      public override void ExecuteResult(ControllerContext context)
      {
        context.HttpContext.Response.StatusCode = 301;
        context.HttpContext.Response.RedirectLocation = this.Url;
        context.HttpContext.Response.End();
      }
    }
