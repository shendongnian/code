    [FormatFilter]
    public abstract class FormatController : Controller
    {
      protected ActionResult FormatOrView(object model)
      {
        var filter = HttpContext.RequestServices.GetRequiredService<FormatFilter>();
        if (filter.GetFormat(ControllerContext) == null)
        {
          return View(model);
        }
        else
        {
          return new ObjectResult(model);
        }
      }
    }
