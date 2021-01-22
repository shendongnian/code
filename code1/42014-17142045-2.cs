    public static class ExtensionMethods
    {
        private static Action EmptyDelegate = delegate() { };
        public static void Refresh(this UIElement uiElement)
        {
            uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }
