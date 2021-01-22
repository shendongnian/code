    public partial class XText
    {
        public static DependencyProperty ValueProperty =
            DependencyProperty.Register(
                "Value",
                typeof(string),
                typeof(XText),
                new FrameworkPropertyMetadata(null)
            );
        public string Value
        {
            get { return ((string)(base.GetValue(XText.ValueProperty))); }
            set { base.SetValue(XText.ValueProperty, value); }
        }
        ...
    }
