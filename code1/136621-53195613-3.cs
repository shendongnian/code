    public class UpdateManager
    {
        public event EventHandler DirtyChanged;
        private readonly BindingSource _bindingSource;
        // Stores original and current values of all bindings.
        private readonly Dictionary<string, (object original, object current)> _values =
            new Dictionary<string, (object original, object current)>();
        public UpdateManager(BindingSource bindingSource)
        {
            _bindingSource = bindingSource;
            bindingSource.CurrencyManager.Bindings.CollectionChanged += Bindings_CollectionChanged;
            bindingSource.BindingComplete += BindingSource_BindingComplete;
        }
        private bool _dirty;
        public bool Dirty
        {
            get {
                return _dirty;
            }
            set {
                if (value != _dirty) {
                    _dirty = value;
                    DirtyChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        private void Bindings_CollectionChanged(object sender, CollectionChangeEventArgs e)
        {
            // Initialize the values information for the binding.
            if (e.Element is Binding binding && GetCurrentValue(binding, out object value)) {
                _values[binding.BindingMemberInfo.BindingField] = (value, value);
            }
        }
        private void BindingSource_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate &&
                e.BindingCompleteState == BindingCompleteState.Success) {
                UpdateDirty(e.Binding);
            }
        }
        private void UpdateDirty(Binding binding)
        {
            if (GetCurrentValue(binding, out object currentValue)) {
                string propertyName = binding.BindingMemberInfo.BindingField;
                var valueInfo = _values[propertyName];
                _values[propertyName] = (valueInfo.original, currentValue);
                if (Object.Equals(valueInfo.original, currentValue)) {
                    Dirty = _values.Any(kvp => !Object.Equals(kvp.Value.original, kvp.Value.current));
                } else {
                    Dirty = true;
                }
            }
        }
        private bool GetCurrentValue(Binding binding, out object value)
        {
            object model = binding.BindingManagerBase?.Current;
            if (model != null) {
                // Get current value in business object (model) with Reflection.
                Type modelType = model.GetType();
                string propertyName = binding.BindingMemberInfo.BindingField;
                PropertyInfo modelProp = modelType.GetProperty(propertyName);
                value = modelProp.GetValue(model);
                return true;
            }
            value = null;
            return false;
        }
    }
