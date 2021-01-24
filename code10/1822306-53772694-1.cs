    public class CommaDelimitedArrayBinder : System.Web.Http.ModelBinding.IModelBinder
    {
        public CommaDelimitedArrayBinder()
        {
    
        }
    
        public bool BindModel(
                System.Web.Http.Controllers.HttpActionContext actionContext,
                System.Web.Http.ModelBinding.ModelBindingContext bindingContext)
        {
            return true;
        }
    }
