	public class MyArgModelBinder : System.Web.Http.ModelBinding.IModelBinder
	{
		public bool BindModel(HttpActionContext actionContext, System.Web.Http.ModelBinding.ModelBindingContext bindingContext)
		{
			var val = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
	
            // transform to upper-case
            var transformedValue = val.AttemptedValue.ToUpperInvariant();
			bindingContext.Model = transformedValue;
			
			return true;
		}
	}
