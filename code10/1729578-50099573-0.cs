    [TemplatePart(Name = "PreText", Type = typeof(TextBlock))]
    public class ExtendedTextBox : TextBox
    {
        public static readonly DependencyProperty PreTextDependency = DependencyProperty.Register("PreText", typeof(string), typeof(ExtendedTextBox));
        public string PreText
        {
            get
            {
                return (string)GetValue(PreTextDependency);
            }
            set
            {
                SetValue(PreTextDependency, value);
            }
        }
        private TextBlock preTextBlock;
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            preTextBlock = GetTemplateChild("PreText") as TextBlock;
            Binding preTextBinding = new Binding("PreText");
            preTextBinding.Source = this;
            preTextBinding.Mode = BindingMode.TwoWay;
            preTextBlock.SetBinding(TextBlock.TextProperty, preTextBinding);
        }
    }
