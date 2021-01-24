    [ContentProperty(Name = "Content")]
    public sealed class TestingControl : Control
    {
        public TestingControl()
        {
            this.DefaultStyleKey = typeof(TestingControl);
        }
        public object Content
        {
            get { return (string)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(string), typeof(TestingControl), new PropertyMetadata(string.Empty));
    }
