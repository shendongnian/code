    public class TextBoxEx : TextBox
    {
        public TextBoxEx()
        {
            AddHandler(LostFocusEvent,
              new RoutedEventHandler(CallConverter), true);
        }
        public Type SourceType
        {
            get { return (Type)GetValue(SourceTypeProperty); }
            set { SetValue(SourceTypeProperty, value); }
        }
        // Using a DependencyProperty as the backing store for SourceType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SourceTypeProperty =
            DependencyProperty.Register("SourceType", typeof(Type), typeof(TextBoxEx), new UIPropertyMetadata(null));
        private static void CallConverter(object sender, RoutedEventArgs e)
        {
            TextBoxEx textBoxEx = sender as TextBoxEx;
            if (textBoxEx.Style == null) {
                return;
            }
            if (textBoxEx.SourceType == null) {
            }
            foreach (Setter setter in textBoxEx.Style.Setters) {
                if (setter.Property.ToString() == "Text") {
                    if (! (setter.Value is Binding) ) {
                        return;
                    }
                    Binding binding = setter.Value as Binding;
                    if (binding.Converter == null) {
                        return;
                    }
                    object value = binding.Converter.ConvertBack(textBoxEx.Text, textBoxEx.SourceType, binding.ConverterParameter, System.Globalization.CultureInfo.CurrentCulture);
                    value = binding.Converter.Convert(value, typeof(string), binding.ConverterParameter, System.Globalization.CultureInfo.CurrentCulture);
                    if (!(value is string)) {
                        return;
                    }
                    textBoxEx.Text = (string)value;
                }
            }
        }
    }
