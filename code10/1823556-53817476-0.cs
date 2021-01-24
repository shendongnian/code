    public class InputBindingsBehavior
    {
        public static readonly DependencyProperty InputBindingsProperty = DependencyProperty.RegisterAttached(
            "InputBindings", typeof(IEnumerable<InputBinding>), typeof(InputBindingsBehavior), new PropertyMetadata(null, new PropertyChangedCallback(Callback)));
        public static void SetInputBindings(UIElement element, IEnumerable<InputBinding> value)
        {
            element.SetValue(InputBindingsProperty, value);
        }
        public static IEnumerable<InputBinding> GetInputBindings(UIElement element)
        {
            return (IEnumerable<InputBinding>)element.GetValue(InputBindingsProperty);
        }
        private static void Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement uiElement = (UIElement)d;
            uiElement.InputBindings.Clear();
            IEnumerable<InputBinding> inputBindings = e.NewValue as IEnumerable<InputBinding>;
            if (inputBindings != null)
            {
                foreach (InputBinding inputBinding in inputBindings)
                    uiElement.InputBindings.Add(inputBinding);
            }
        }
    }
