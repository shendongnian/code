    using System.Windows.Interactivity;
    public class EnterDownEventTrigger : EventTrigger 
    {    
        public EnterDownEventTrigger() : base("KeyDown") { }
    
        protected override void OnEvent(EventArgs eventArgs) 
        {
            var e = eventArgs as KeyEventArgs;
            if (e != null && e.Key == Key.Enter)
                this.InvokeActions(eventArgs);
        }
    }
