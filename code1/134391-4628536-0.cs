    public class CustomControllerBase : Controller
    {
        public PartialViewResult EditorFor(object model)
        {
            return PartialView("EditorTemplates/" + model.GetType().Name, model);
        }
        public PartialViewResult DisplayFor(object model)
        {
            return PartialView("DisplayTemplates/" + model.GetType().Name, model);
        }
    }
