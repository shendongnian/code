    public class MyBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            bindingContext.ModelType = System.Type.GetType(controllerContext.HttpContext.Request["modelType"]);
           
            return base.BindModel(controllerContext, bindingContext);
        }
    }
