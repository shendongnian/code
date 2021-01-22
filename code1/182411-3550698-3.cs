    public partial class XText
    {
        public XText()
        {
           InitializeComponent();
           MyText.SetBinding(TextBox.TextProperty, new Binding() 
           { 
              Source = this,  
              Path = new PropertyPath("Value"), 
              Mode = BindingMode.TwoWay
           });
        }
        public static DependencyProperty ValueProperty =
            DependencyProperty.Register(
                "Value",
                typeof(string),
                typeof(XText),
                new PropertyMetadata(null)
            );
    
        public string Value
        {
            get { return ((string)(GetValue(ValueProperty))); }
            set { SetValue(ValueProperty, value); }
        }
    
        ...
    }
