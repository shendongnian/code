    public class FrameNavigationBehavior : Behavior<Frame>
    {
        public static readonly DependencyProperty CanGoForwardProperty = DependencyProperty.Register(
            "CanGoForward", typeof (bool), typeof (FrameNavigationBehavior), new PropertyMetadata(true));
        public static readonly DependencyProperty CanGoBackwardProperty = DependencyProperty.Register(
            "CanGoBackward", typeof (bool), typeof (FrameNavigationBehavior), new PropertyMetadata(true));
        public static readonly DependencyProperty CanRefreshProperty = DependencyProperty.Register(
            "CanRefresh", typeof (bool), typeof (FrameNavigationBehavior), new PropertyMetadata(true));
        public bool CanGoForward
        {
            get { return (bool) GetValue(CanGoForwardProperty); }
            set { SetValue(CanGoForwardProperty, value); }
        }
        public bool CanGoBackward
        {
            get { return (bool) GetValue(CanGoBackwardProperty); }
            set { SetValue(CanGoBackwardProperty, value); }
        }
        public bool CanRefresh
        {
            get { return (bool) GetValue(CanRefreshProperty); }
            set { SetValue(CanRefreshProperty, value); }
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Navigating += AssociatedObject_Navigating;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Navigating -= AssociatedObject_Navigating;
        }
        private void AssociatedObject_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            NavigationMode navigationMode = e.NavigationMode;
            switch (navigationMode)
            {
                case NavigationMode.New:
                    break;
                case NavigationMode.Back:
                    if (!CanGoBackward)
                    {
                        e.Cancel = true;
                    }
                    break;
                case NavigationMode.Forward:
                    if (!CanGoForward)
                    {
                        e.Cancel = true;
                    }
                    break;
                case NavigationMode.Refresh:
                    if (!CanRefresh)
                    {
                        e.Cancel = true;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
