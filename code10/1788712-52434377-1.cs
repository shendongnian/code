    namespace MultiVid
    {
    public sealed class CustomMediaTransportControls : MediaTransportControls
    {
        public event EventHandler<EventArgs> Moins10click;
        public CustomMediaTransportControls()
        {
            this.DefaultStyleKey = typeof(CustomMediaTransportControls);
        }
        protected override void OnApplyTemplate()
        {
            // Find the custom button and create an event handler for its Click event.
            var Moins10Button = GetTemplateChild("Moins10") as Button;
            Moins10Button.Click += Moins10Button_Click;
            base.OnApplyTemplate();
        }
        private void Moins10Button_Click(object sender, RoutedEventArgs e)
        {
            var handler = Moins10click;
            if (handler != null)
        {
            handler(this, EventArgs.Empty);
        }
        }
    }
    }
