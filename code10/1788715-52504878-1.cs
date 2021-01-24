        namespace yournamespace
        {
        public sealed class CustomMediaTransportControls : MediaTransportControls
        {
        
        //Add an eventhandler for each button you added
        public event EventHandler<EventArgs> Plus500;
        public CustomMediaTransportControls()
        {
            this.DefaultStyleKey = typeof(CustomMediaTransportControls);
        }
        //Add an override for each button you created in the following format:
        protected override void OnApplyTemplate()
        {
            Button Plus500Button = GetTemplateChild("Plus500Button") as Button;
            Plus500Button.Click += Plus500Button_Click;
        }
        //To raise an event when the button is clicked, add the following code for each button you added:
        private void Plus500B_Click(object sender, RoutedEventArgs e)
        {            
            Plus500?.Invoke(this, EventArgs.Empty);
        }
