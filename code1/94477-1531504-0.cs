    public class MyBehavior : Behavior<Button>
    {
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message",
            typeof(string), typeof(MyBehavior),
            new PropertyMetadata("Default message"));
    
        public MyBehavior()
            : base()
        { }
    
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }
    
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Click += new RoutedEventHandler(AssociatedObject_Click);
        }
    
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Click -= new RoutedEventHandler(AssociatedObject_Click);
        }
    
        void AssociatedObject_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Message);
        }
    }
