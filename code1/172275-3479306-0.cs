    public class OfferController : Controller
    {
        [HttpPost]
        public JsonResult EditForm(int Id)
        {
            var model = Mapper.Map<Offer, OfferEditModel>(_repo.GetOffer(Id));
            return Json(new { status = "ok", partial = this.RenderPartialViewToString("Edit", model) });
        }
    }
    public static partial class ControllerExtensions
    {
        public static string RenderPartialViewToString(this ControllerBase controller, string partialPath, object model)
        {
            if (string.IsNullOrEmpty(partialPath))
                partialPath = controller.ControllerContext.RouteData.GetRequiredString("action");
            controller.ViewData.Model = model;
            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, partialPath);
                ViewContext viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                // copy model state items to the html helper 
                foreach (var item in viewContext.Controller.ViewData.ModelState)
                    if (!viewContext.ViewData.ModelState.Keys.Contains(item.Key))
                    {
                        viewContext.ViewData.ModelState.Add(item);
                    }
                    
                viewResult.View.Render(viewContext, sw);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
