    using System.Web.Mvc; 
    using System.Diagnostics;
    
    namespace MvcApplication1  {
        public class ActionTimerAttribute : ActionFilterAttribute
            {
                public ActionTimerAttribute()
                {
                    // Make sure this attribute executes after every other one!
                    this.Order = int.MaxValue;
                }
        
                public override void OnActionExecuting(ActionExecutingContext filterContext)
                {
                    var controller = filterContext.Controller;
                    if (controller != null)
                    {
                        var timer = new Stopwatch();
                        controller.ViewData["_ActionTimer"] = timer;
                        timer.Start();
                    }
                    base.OnActionExecuting(filterContext);
                }
        
                public override void OnActionExecuted(ActionExecutedContext filterContext)
                {
                    var controller = filterContext.Controller;
                    if (controller != null)
                    {
                        var timer = (Stopwatch)controller.ViewData["_ActionTimer"];
                        if (timer != null)
                        {
                            timer.Stop();
                            controller.ViewData["_ElapsedTime"] = timer.ElapsedMilliseconds;
                        }
                    }
                }
            } }
