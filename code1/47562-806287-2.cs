public ActionResult JsonExceptionHandler(Func < object > action) {
  try {
    var res = action();
    return res == null ? JsonSuccess() : JsonSuccess(res);
  } catch (Exception exc) {
    controller.ControllerContext.HttpContext.AddError(exc);
    return JsonFailure(new {
      errorMessage = exc.Message
    });
  }
}
**Filter:**
public override void OnActionExecuted(ActionExecutedContext filterContext) {
  var exception = filterContext.Exception ? ? filterContext.HttpContext.Error;
  if (exception != null) {
    //logger.Error(xxx);
  }
  if (filterContext.Result != null &&
    filterContext.HttpContext.Error != null) {
    filterContext.HttpContext.ClearError();
  }
  base.OnActionExecuted(filterContext);
}
