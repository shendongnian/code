            public Visibility ActionsVisible
        {
            get { return (Visibility)GetValue(ActionsVisibleProperty); }
            set { SetValue(ActionsVisibleProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ActionsVisible.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ActionsVisibleProperty =
            DependencyProperty.Register("ActionsVisible", typeof(Visibility), typeof(FooForm));
