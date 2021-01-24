    public class RoutedEventTrigger : EventTriggerBase<DependencyObject>
    {
        RoutedEvent routedEvent;
        public RoutedEvent RoutedEvent
        {
            get
            {
                return routedEvent;
            }
            set 
            { 
                routedEvent = value;
            }
        }
        public RoutedEventTrigger()
        {
        }
        protected override void OnAttached()
        {
            Behavior behavior = base.AssociatedObject as Behavior;
            FrameworkElement associatedElement = base.AssociatedObject as FrameworkElement;
            if (behavior != null)
            {
                associatedElement = ((IAttachedObject)behavior).AssociatedObject as FrameworkElement;
            } 
            if (associatedElement == null)
            {
                throw new ArgumentException("This only works with framework elements");
            }
            if (RoutedEvent != null)
            {
                associatedElement.AddHandler(RoutedEvent, new RoutedEventHandler(this.OnRoutedEvent));
            }
        }
        void OnRoutedEvent(object sender, RoutedEventArgs args)
        {
             base.OnEvent(args);
        }
        protected override string GetEventName()
        {
            return RoutedEvent.Name;
        }
    }
