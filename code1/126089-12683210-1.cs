    namespace MyApp.Web.Mvc
    {
	    interface IPropertyBinder
	    {
	        object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext, MemberDescriptor memberDescriptor);
	    }
    }
