    class LineCountBehavior : Behavior<TextBox>
    {
        public int LineCount
        {
            get { return (int)GetValue(LineCountProperty); }
            set { SetValue(LineCountProperty, value); }
        }
        public static readonly DependencyProperty LineCountProperty =
        DependencyProperty.Register("LineCount", typeof(int), typeof(LineCountBehavior), new PropertyMetadata(0));
        protected override void OnAttached()
        {
            AssociatedObject.LayoutUpdated += RefreshLineCount;
            AssociatedObject.TextChanged += RefreshLineCount;
        }
        protected override void OnDetaching()
        {
            AssociatedObject.LayoutUpdated -= RefreshLineCount;
            AssociatedObject.TextChanged -= RefreshLineCount;
        }
        private void RefreshLineCount(object sender, EventArgs e)
        {
          LineCount = AssociatedObject.LineCount;
        }
    }
