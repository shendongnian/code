    public class TranslateExtension : MarkupExtension
    {
        private readonly BindingBase _binding;
        public TranslateExtension(BindingBase binding)
        {
            _binding = binding;
        }
        public TranslateExtension(string key)
        {
            Key = key;
        }
        [ConstructorArgument("key")]
        public string Key { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_binding != null)
            {
                var pvt = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
                var target = pvt.TargetObject as DependencyObject;
                // if we are inside a template, WPF will call us again when it is applied
                if (target == null)
                    return this; 
                BindingOperations.SetBinding(target, ValueProperty, _binding);
                Key = (string)target.GetValue(ValueProperty);
                BindingOperations.ClearBinding(target, ValueProperty);
            }
            // now do the translation using Key
            return ...;
        }
        
        private static readonly DependencyProperty ValueProperty = 
            DependencyProperty.RegisterAttached("Value", typeof(string), typeof(TranslateExtension));
    }
