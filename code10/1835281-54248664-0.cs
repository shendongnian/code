    public partial class MyBox : UserControl
    {
        public MyBox()
        {
            InitializeComponent();
        }
    
        public bool Rounded
        {
            get { return (bool)GetValue(RoundedProperty); }
            set { SetValue(RoundedProperty, value); }
        }
    
        public static readonly DependencyProperty RoundedProperty = DependencyProperty.Register("Rounded", typeof(bool), typeof(MyBox), new PropertyMetadata(false, RoundedChanged));
        
        private static void RoundedChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            bool value = (bool)e.NewValue;
            MyBox thisMyBox = (MyBox)sender;
    
            // Hide/show the edges
            thisMyBox.edgeRounded.Visibility = (value ? Visibility.Visible : Visibility.Hidden);
            thisMyBox.edgePolygon.Visibility = (value ? Visibility.Hidden : Visibility.Visible);
        }
    }
