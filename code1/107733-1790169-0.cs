    class TestClass : DependencyObject
    {
        public int testProperty
        {
            get { return (int)GetValue(TestPropertyProperty); }
            set { SetValue(TestPropertyProperty, value); }
        }
        public static readonly DependencyProperty TestPropertyProperty =
            DependencyProperty.Register("testProperty", typeof(int), typeof(TestClass));
        public TestClass()
        {
            testProperty = 10;
        }
    }
