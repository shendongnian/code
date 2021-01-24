    [ContentProperty("Conditions"), Preserve(AllMembers = true)]
    public class ContainerWithShadow : ContentView
    {
        public static readonly BindableProperty StateProperty = BindableProperty.Create(nameof(ContainerWithShadowChild), typeof(object), typeof(View), propertyChanged:PropertyChanged);
        private static void PropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
        }
        public View ContainerWithShadowChild
        {
            get => (View)GetValue(StateProperty);
            set => SetValue(StateProperty, value);
        }
    }
