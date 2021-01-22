    public class CustomModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
    
            if (bindingContext.ModelType.Namespace.EndsWith("Models.Entities") && !bindingContext.ModelType.IsEnum && value != null)
            {
                if (Utilities.IsInteger(value.AttemptedValue))
                {
                    var repository = ServiceLocator.Current.GetInstance(typeof(IRepository<>).MakeGenericType(bindingContext.ModelType));
                    return repository.GetType().InvokeMember("GetByID", BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.Public, null, repository, new object[] { Convert.ToInt32(value.AttemptedValue) });
                }
                else if (value.AttemptedValue == "")
                    return null;
            }
            
            return base.BindModel(controllerContext, bindingContext);
        }
    }
