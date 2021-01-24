    public class MouseWheelButtonEventTrigger : System.Windows.Interactivity.EventTrigger
    {
        public MouseWheelButtonEventTrigger()
        {
            EventName = "MouseDown";
        }
        protected override void OnEvent(EventArgs eventArgs)
        {
            MouseButtonEventArgs mbea = eventArgs as MouseButtonEventArgs;
            if (mbea != null && mbea.ChangedButton == MouseButton.Middle)
                base.OnEvent(eventArgs);
        }
    }
