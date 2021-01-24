    public ActionResult ActionName (CustomRequest request) {
    
    }
    [ModelBinder(typeof(CustomModelBinder))]
    public class CustomRequest
    {
        public bool itemOnly;
        public string[] addedArticles;
    }
    public class CustomModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.RequestContext.HttpContext.Request;
            var itemOnly =bool.Parse( request.QueryString["itemOnly"]);
            var addedArticles = request.QueryString["addedArticles"].Split(',');
            return new CustomRequest(){itemOnly=itemOnly,addedArticles= addedArticles};
        }
    }
