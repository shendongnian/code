    public class FrameAnimator : DependencyObject
    {
        public static readonly DependencyProperty FrameNextNavigationStotryboardProperty = DependencyProperty.RegisterAttached("FrameNextNavigationStotryboard", typeof(Storyboard), typeof(FrameAnimator), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure, FrameNextNavigationStotryboardProprtyChanged));
        private static void FrameNextNavigationStotryboardProprtyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Frame)
            {
                
                   Storyboard st = GetFrameNextNavigationStotryboard(d);
                if (st != null)
                {
                    (d as Frame).Navigating += (sm, ar) =>
                    {
                        if (ar.NavigationMode != System.Windows.Navigation.NavigationMode.Back)
                        {
                            st.Begin((d as Frame));
                        }
                    };
                }
            }
        }
        public static void SetFrameNextNavigationStotryboard(DependencyObject control, Storyboard st)
        {
            control.SetValue(FrameNextNavigationStotryboardProperty, st);
        }
        public static Storyboard GetFrameNextNavigationStotryboard(DependencyObject control)
        {
            var val = control.GetValue(FrameNextNavigationStotryboardProperty);
            if (val is Storyboard)
                return (Storyboard)val;
            return null;
        }
    
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////
        /// </summary>
    
        public static readonly DependencyProperty FrameBackNavigationStotryboardProperty = DependencyProperty.RegisterAttached("FrameBackNavigationStotryboard", typeof(Storyboard), typeof(FrameAnimator), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure, FrameBackNavigationStotryboardProprtyChanged));
        private static void FrameBackNavigationStotryboardProprtyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Frame)
            {
                Storyboard st = GetFrameBackNavigationStotryboard(d);
                if (st != null)
                {
                    (d as Frame).Navigating += (sm, ar) =>
                    {
                        if (ar.NavigationMode == System.Windows.Navigation.NavigationMode.Back)
                        {
                            st.Begin((d as Frame));
                        }
                    };
                }
            }
        }
        public static void SetFrameBackNavigationStotryboard(DependencyObject control, Storyboard st)
        {
            control.SetValue(FrameBackNavigationStotryboardProperty, st);
        }
        public static Storyboard GetFrameBackNavigationStotryboard(DependencyObject control)
        {
            var val = control.GetValue(FrameBackNavigationStotryboardProperty);
            if (val is Storyboard)
                return (Storyboard)val;
            return null;
        }
    }
