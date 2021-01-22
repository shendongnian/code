	public class S2kBoolAttribute : CustomModelBinderAttribute, IModelBinder
	{
		public override IModelBinder GetBinder()
		{
			return this;
		}
		public object BindModel( ControllerContext controllerContext, ModelBindingContext bindingContext )
		{
			ValueProviderResult result;
			return bindingContext.ValueProvider.TryGetValue( bindingContext.ModelName, out result )
				? (S2kBool)result.ConvertTo( typeof( bool ) )
				: null;
		}
	}
