    using System; using System.Windows.Input; using System.Windows.Interactivity;
    public class KeyDownEventTrigger : EventTrigger
    {
        public KeyDownEventTrigger() : base("KeyDown")
        {
        }
        protected override void OnEvent(EventArgs eventArgs)
        {
            var e = eventArgs as KeyEventArgs;
            if (e != null && e.Key == Key.Tab)
            { 
                this.InvokeActions(eventArgs);                
            }
        }
    }
