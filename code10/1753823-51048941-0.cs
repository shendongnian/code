    public class FiltroSeleccionadoCollectionModelBinder : IModelBinder
    {
    public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }
        if (bindingContext.ModelMetadata.ModelType == typeof(DateTime))
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            var str = valueProviderResult.AttemptedValue;
            
            //convert str to List<FiltroSeleccionado> and return it;
        }
        return null;
    }
