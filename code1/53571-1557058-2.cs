    namespace WPFControls
    {
        /// <summary>
        /// Interaction logic for ShadowedTextBox.xaml
        /// </summary>
        public partial class ShadowedTextBox : UserControl
        {
            public event TextChangedEventHandler TextChanged;
    
            public ShadowedTextBox()
            {
                InitializeComponent();
            }
    
            public static readonly DependencyProperty WatermarkProperty =
                DependencyProperty.Register("Watermark",
                                            typeof (string),
                                            typeof (ShadowedTextBox),
                                            new UIPropertyMetadata(string.Empty));
    
            public static readonly DependencyProperty TextProperty =
                DependencyProperty.Register("Text",
                                            typeof (string),
                                            typeof (ShadowedTextBox),
                                            new UIPropertyMetadata(string.Empty));
    
            public static readonly DependencyProperty TextChangedProperty =
                DependencyProperty.Register("TextChanged",
                                            typeof (TextChangedEventHandler),
                                            typeof (ShadowedTextBox),
                                            new UIPropertyMetadata(null));
    
            public string Watermark
            {
                get { return (string)GetValue(WatermarkProperty); }
                set
                {
                    SetValue(WatermarkProperty, value);
                }
            }
    
            public string Text
            {
                get { return (string) GetValue(TextProperty); }
                set{SetValue(TextProperty,value);}
            }
    
            private void textBox_TextChanged(object sender, TextChangedEventArgs e)
            {
                if (TextChanged != null) TextChanged(this, e);
            }
    
            public void Clear()
            {
                textBox.Clear();
            }
            
        }
    }
