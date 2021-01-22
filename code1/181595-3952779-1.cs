    public static class NavigationHelpers{
        public static void MoveFocus(this FrameworkElement control, FocusNavigationDirection direction = FocusNavigationDirection.Next, bool wrap = true) {
            TraversalRequest request = new TraversalRequest(direction);
            request.Wrapped = wrap;
            control.MoveFocus(request);
        }
    }
