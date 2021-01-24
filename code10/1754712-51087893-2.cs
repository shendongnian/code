    public class AttributeModelBinder : IModelBinder
    {
        public static object _lock = new object();
        private static Dictionary<Type, IEnumerable<MappedProperty>> _mappings = new Dictionary<Type, IEnumerable<MappedProperty>>();
        public IEnumerable<MappedProperty> GetMapping(Type type)
        {
            if (_mappings.TryGetValue(type, out var result)) return result; // Found
            lock (_lock)
            {
                if (_mappings.TryGetValue(type, out result)) return result; // Check again after lock
                return (_mappings[type] = type.GetProperties().Select(p => new MappedProperty(p)));
            }
        }
        public object Convert(Type target, string value)
        {
            try
            {
                var converter = TypeDescriptor.GetConverter(target);
                if (converter != null)
                    return converter.ConvertFromString(value);
                else
                    return target.IsValueType ? Activator.CreateInstance(target) : null;
            }
            catch (NotSupportedException)
            {
                return target.IsValueType ? Activator.CreateInstance(target) : null;
            }
        }
        public void SetValue(object model, MappedProperty p, IValueProvider valueProvider)
        {
            var value = valueProvider.GetValue(p.Target)?.AttemptedValue;
            if (value == null) return;
            p.Info.SetValue(model, this.Convert(p.Info.PropertyType, value));
        }
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            try
            {
                var model = Activator.CreateInstance(bindingContext.ModelType);
                var mappings = this.GetMapping(bindingContext.ModelType);
                foreach (var p in mappings)
                    this.SetValue(model, p, bindingContext.ValueProvider);
                bindingContext.Model = model;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
