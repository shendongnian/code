    public partial class MyUserControl : UserControl
    {
        public static readonly DependencyProperty RequesterProperty
            = DependencyProperty.Register("Requester", typeof(Requester), typeof(MainWindow),
                new PropertyMetadata(default(Requester), OnRequesterChanged));
    
        public MyUserControl()
        {
            InitializeComponent();
        }
    
        public Requester Requester
        {
            get => (Requester) GetValue(RequesterProperty);
            set => SetValue(RequesterProperty, value);
        }
    
        private static void OnRequesterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            => ((Requester) e.NewValue).DataRequested += ((MyUserControl) d).OnDataRequested;
    
        private void OnDataRequested()
        {
            Requester.Data = "XD";
        }
    }
