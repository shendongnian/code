        public class FooTypeBinder : IModelBinder
        {
            public Task BindModelAsync(ModelBindingContext bindingContext) => Task.Run(() => this.BindModel(bindingContext));
            private void BindModel(ModelBindingContext bindingContext)
            {
                var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
                if (valueProviderResult.Length == 0)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, "No value was provided for enum");
                    return;
                }
                var stringValue = valueProviderResult.FirstValue;
                try
                {
                    bindingContext.Model = this.FromString(stringValue);
                }
                catch (NoMatchFoundException ex)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, ex.Message);
                }
            }
            private FooType FromString(string input)
            {
                //Here you should implement your custom way of checking the [EnumMember] attribute, and convert input into your enum.
                if (Enum.TryParse(typeof(FooType), input, true, out object value))
                {
                    return (FooType)value;
                }
                else return input.DehumanizeTo<FooType>();
            }
        }
