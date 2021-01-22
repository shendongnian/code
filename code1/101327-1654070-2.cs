    public class RedirectWithStatusCodeResult : ActionResult
    {
      public HttpStatusCode StatusCode { get; set; }
      public string Url { get; set; }
      public override void ExecuteResult(ControllerContext context)
      {
        context.HttpContext.Response.StatusCode = (int)this.StatusCode;
        context.HttpContext.Response.RedirectLocation = this.Url;
        context.HttpContext.Response.End();
      }
    }
