    public class CustomModelBinder: DefaultModelBinder
    {
        protected override void OnModelUpdated(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            controllerContext.Controller.ViewData.Model = bindingContext.Model;
            base.OnModelUpdated(controllerContext, bindingContext);
        }
    }
