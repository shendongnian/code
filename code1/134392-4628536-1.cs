    public class CustomControllerBase : Controller
    {
        public PartialViewResult EditorFor<TModel>(TModel model)
        {
            return PartialView("EditorTemplates/" + typeof(TModel).Name, model);
        }
        public PartialViewResult DisplayFor<TModel>(TModel model)
        {
            return PartialView("DisplayTemplates/" + typeof(TModel).Name, model);
        }
    }
