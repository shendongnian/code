    public static class PropertyPathHelper
    {
        public static object GetValue(object obj, string propertyPath)
        {
            Binding binding = new Binding(propertyPath);
            binding.Mode = BindingMode.OneTime;
            binding.Source = obj;
            BindingOperations.SetBinding(_dummy, Dummy.ValueProperty, binding);
            return _dummy.GetValue(Dummy.ValueProperty);
        }
    
        private static readonly Dummy _dummy = new Dummy();
    
        private class Dummy : DependencyObject
        {
            public static readonly DependencyProperty ValueProperty =
                DependencyProperty.Register("Value", typeof(object), typeof(Dummy), new UIPropertyMetadata(null));
        }
    }
