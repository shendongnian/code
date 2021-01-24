        public partial class NumericUpDownControl : UserControl
        {
            public static readonly DependencyProperty ValueProperty =
                DependencyProperty.Register("Value", typeof(int),typeof(NumericUpDownControl),new PropertyMetadata(OnValueChanged));
    
            private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                ((NumericUpDownControl) d).TextBox.Text = e.NewValue?.ToString() ?? string.Empty;
            }
    
            public int Value
            {
                get => (int)GetValue(ValueProperty);
                set => SetValue(ValueProperty, value);
            }
    
            public NumericUpDownControl()
            {
                InitializeComponent();
            }
        }
    }
