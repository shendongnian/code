    public partial class MyUserControl : UserControl
        {
            public static readonly DependencyProperty TargetPropertyNameProperty = DependencyProperty.Register(
                "TargetPropertyName",
                typeof(string),
                typeof(MyUserControl),
                new UIPropertyMetadata(TargetPropertyNamePropertyChangedHandler)
            );
    
            public static void TargetPropertyNamePropertyChangedHandler(DependencyObject sender, DependencyPropertyChangedEventArgs e)
            {
                var MyUserControl = sender as MyUserControl;
    
                MyUserControl.TargetPropertyName = (string)e.NewValue;
            }
    
            public string TargetPropertyName
            {
                get
                {
                    return (string)GetValue(TargetPropertyNameProperty);
                }
                set
                {
                    SetValue(TargetPropertyNameProperty, value);
                    BindTextPropertyToTargetPropertyNameOnce()
                }
            }
    
            public MyUserControl()
            {
                InitializeComponent();
            }
    
            private bool _firstRun = true;
    
            private void BindTextPropertyToTargetPropertyNameOnce()
            {
                if (_firstRun)
                {
                    _firstRun = false;
                    var binding = new Binding(TargetPropertyName)
                    {
                        Mode = BindingMode.TwoWay,
                        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                        ValidatesOnDataErrors = true,
                        NotifyOnValidationError = true
                    };
    
                    MainTextBox.SetBinding(TextBox.TextProperty, binding);
                }
            }
        }
