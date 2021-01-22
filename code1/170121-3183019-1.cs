    public static class ContentAttach
    {
        public static readonly DependencyProperty StateProperty = DependencyProperty.RegisterAttached(
            "State", typeof(DockableContentState), typeof(ContentAttach), new PropertyMetadata(StateChanged));
        public static void SetState(DockableContent element, DockableContentState value)
        {
            element.SetValue(StateProperty, value);
        }
        public static DockableContentState GetState(DockableContent element)
        {
            return (DockableContentState)element.GetValue(StateProperty);
        }
        private static void StateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (DockableContent)d;
            var state = (DockableContentState)e.NewValue;
            switch (state)
            {
                // Call methods in here to change State.
            }
        }
    }
