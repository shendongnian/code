    public class MyTypeBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext,
                                              ModelBindingContext bindingContext,
                                              Type modelType)
        {
            return MyType.CreateNewMyType();
        }
    }
