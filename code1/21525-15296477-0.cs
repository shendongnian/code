    public class MyDefaultModelBinder : System.Web.Mvc.DefaultModelBinder
	{
		protected override object CreateModel(System.Web.Mvc.ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext, Type modelType)
		{
			return base.CreateModel(controllerContext, bindingContext, modelType);
		}
	}
