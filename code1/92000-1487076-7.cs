    public class MyModelBinder
        : DefaultModelBinder {
    
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
    
             if (HasGenericTypeBase(bindingContext.ModelType, typeof(MyType<>)) { 
                 // do your thing
             }
             return base.BindModel(controllerContext, bindingContext);
        }
    }
