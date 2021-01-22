	protected override object GetPropertyValue(
		ControllerContext controllerContext,
		ModelBindingContext bindingContext,
		PropertyDescriptor propertyDescriptor,
		IModelBinder propertyBinder)
	{
		PropertyBinderAttribute propertyBinderAttribute =
			TryFindPropertyBinderAttribute(propertyDescriptor);
		if (propertyBinderAttribute != null)
		{
			propertyBinder = CreateBinder(propertyBinderAttribute);
		}
		return base.GetPropertyValue(
			controllerContext,
			bindingContext,
			propertyDescriptor,
			propertyBinder);
	}
