     public class FrameAnimator : DependencyObject
    {
        public static DependencyProperty FrameNextNavigationStotryboard = DependencyProperty.RegisterAttached("FrameNextNavigationStotryboardProprty", typeof(Storyboard), typeof(FrameAnimator), new PropertyMetadata(null, FrameNextNavigationStotryboardProprtyChanged));
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
            control.SetValue(FrameNextNavigationStotryboard, st);
        }
        public static Storyboard GetFrameNextNavigationStotryboard(DependencyObject control)
        {
            var val = control.GetValue(FrameNextNavigationStotryboard);
            if (val is Storyboard)
                return (Storyboard)val;
            return null;
        }
    
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////
        /// </summary>
        
        public static DependencyProperty FrameBackNavigationStotryboard = DependencyProperty.RegisterAttached("FrameBackNavigationStotryboardProprty", typeof(Storyboard), typeof(FrameAnimator), new PropertyMetadata(null, FrameBackNavigationStotryboardProprtyChanged));
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
            control.SetValue(FrameBackNavigationStotryboard, st);
        }
        public static Storyboard GetFrameBackNavigationStotryboard(DependencyObject control)
        {
            var val = control.GetValue(FrameBackNavigationStotryboard);
            if (val is Storyboard)
                return (Storyboard)val;
            return null;
        } 
    }
