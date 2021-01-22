    public class UpdatePropertySourceWhenEnterPressedExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new DelegateCommand<TextBox>(textbox => textbox.GetBindingExpression(TextBox.TextProperty).UpdateSource());
        }
    }
