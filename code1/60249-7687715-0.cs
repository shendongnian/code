    public class EventBinding : DependencyObject
    {
        public static string GetEventName(DependencyObject obj)
        {
            return (string)obj.GetValue(EventNameProperty);
        }
    
        public static void SetEventName(DependencyObject obj, string value)
        {
            obj.SetValue(EventNameProperty, value);
            var @event = obj.GetType().GetEvent(value);
            var eventHandlerType = @event.EventHandlerType;
            if (eventHandlerType.IsGenericType)
            {
                var eventHandlerMethod = typeof(EventBinding).GetMethod("EventHandlerMethod", BindingFlags.Static | BindingFlags.NonPublic);
                var args = eventHandlerType.GetGenericArguments();
                eventHandlerMethod = eventHandlerMethod.MakeGenericMethod(args);
                @event.AddEventHandler(obj, Delegate.CreateDelegate(eventHandlerType, eventHandlerMethod));
            }
            else
            {
                @event.AddEventHandler(obj, new EventHandler(EventHandlerMethod<EventArgs>));
            }
        }
    
        private static void EventHandlerMethod<TEventArgs>(object sender, TEventArgs e)
            where TEventArgs : EventArgs
        {
            var command = GetCommand(sender as DependencyObject);
            command.Execute(new EventInfo<TEventArgs>(sender, e));
        }
    
        public static readonly DependencyProperty EventNameProperty = 
            DependencyProperty.RegisterAttached("EventName", typeof(string), typeof(EventHandler));
    
        public static ICommand GetCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(CommandProperty);
        }
    
        public static void SetCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(CommandProperty, value);
        }
    
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(EventBinding));
    
    }
    
    public class EventInfo<TEventArgs>
    {
        public object Sender { get; set; }
        public TEventArgs EventArgs { get; set; }
    
        public EventInfo(object sender, TEventArgs e)
        {
            Sender = sender;
            EventArgs = e;
        }
    }
    
    public class EventInfo : EventInfo<EventArgs>
    {
        public EventInfo(object sender, EventArgs e)
            : base(sender, e) { }
    }
