    public override object BindModel(ControllerContext controllerContext, 
                                     ModelBindingContext bindingContext)
    {
        ParentType boundModel = null;
        if (bindingContext.ModelType == typeof(ParentType))
        {
            var myFactory = new MyFactory();
            var someValue = bindingContext.ValueProvider
                                          .GetValue("someFieldId").AttemptedValue;
            ChildType child = myFactory.Create(someValue);
            BindModel(child);
            boundModel = child;
        }
        // change here
        bindingContext.ModelMetadata.Model = boundModel;
        return BindModel(controllerContext, bindingContext);
    }
