    public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
         if ((MyType).IsAssignableFrom(bindingContext.ModelType)) { 
             // do your thing
         }
         return base.BindModel(controllerContext, bindingContext);
    }
