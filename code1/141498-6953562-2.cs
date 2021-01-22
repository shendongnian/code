    /// <summary>
        /// Base for binding references. Usually displayed in dropdowns
        /// </summary>
        public class ReferenceBinder<T> : DefaultModelBinder
            where T : class
        {
    
            private readonly ISession session;
    
            public ReferenceBinder(ISession session)
            {
                this.session = session;
            }
    
    
            public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
    
                var idName = CreateSubPropertyName(bindingContext.ModelName, "ID");
    
                ValueProviderResult result = bindingContext.ValueProvider.GetValue(idName);
    
                int value;
                return (int.TryParse(result.AttemptedValue, out value)) ?  this.session.Load<T>(value) : null;
    
            }
    
    
        }
