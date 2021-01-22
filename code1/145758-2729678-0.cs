    namespace System.Web.Mvc
	{
		class KeepEmptyStringsEmptyModelBinder : DefaultModelBinder
		{
			protected override object GetPropertyValue(ControllerContext controllerContext, ModelBindingContext bindingContext, ComponentModel.PropertyDescriptor propertyDescriptor, IModelBinder propertyBinder)
			{
				return propertyBinder.BindModel(controllerContext, bindingContext);
			}
		}
	}
