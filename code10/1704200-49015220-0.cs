    public class DataChangeTriggerBehavior : Trigger<FrameworkElement>
    {
        public static readonly DependencyProperty BindingProperty = DependencyProperty.Register(
            nameof(Binding), typeof(object), typeof(DataChangeTriggerBehavior), new PropertyMetadata(null, BindingChanged));
    
        public object Binding
        {
            get => (object)GetValue(BindingProperty);
            set => SetValue(BindingProperty, value);
        }
    
        private static void BindingChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            DataChangeTriggerBehavior changeTrigger = (DataChangeTriggerBehavior)dependencyObject;
    
            if (changeTrigger.AssociatedObject == null) return;
    
            Interaction.ExecuteActions(changeTrigger.AssociatedObject, changeTrigger.Actions, args);
        }
    }
