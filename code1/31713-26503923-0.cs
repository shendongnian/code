    /// <summary>
    /// This behavior raises an event when the containing window of a <see cref="UserControl"/> is closing.
    /// </summary>
    public class UserControlSupportsUnloadingEventBehavior : System.Windows.Interactivity.Behavior<UserControl>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += UserControlLoadedHandler;
        }
    
        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= UserControlLoadedHandler;
            var window = Window.GetWindow(AssociatedObject);
            if (window != null)
                window.Closing -= WindowClosingHandler;
        }
    
        /// <summary>
        /// Registers to the containing windows Closing event when the UserControl is loaded.
        /// </summary>
        private void UserControlLoadedHandler(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(AssociatedObject);
            if (window == null)
                throw new Exception(
                    "The UserControl {0} is not contained within a Window. The UserControlSupportsUnloadingEventBehavior cannot be used."
                        .FormatWith(AssociatedObject.GetType().Name));
    
            window.Closing += WindowClosingHandler;
        }
    
        /// <summary>
        /// The containing window is closing, raise the UserControlClosing event.
        /// </summary>
        private void WindowClosingHandler(object sender, CancelEventArgs e)
        {
            OnUserControlClosing();
        }
    
        /// <summary>
        /// This event will be raised when the containing window of the associated <see cref="UserControl"/> is closing.
        /// </summary>
        public event EventHandler UserControlClosing;
    
        protected virtual void OnUserControlClosing()
        {
            var handler = UserControlClosing;
            if (handler != null) 
                handler(this, EventArgs.Empty);
        }
    }
