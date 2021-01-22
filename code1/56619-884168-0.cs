    public class CustomerFormViewModelBinder : DefaultModelBinder
    {
        protected virtual object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            var model = new CustomerFormViewModel(customer)
        }
    }
