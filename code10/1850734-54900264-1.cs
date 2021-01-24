    public sealed class CustomMediaTransportControls : MediaTransportControls
    {
        public CustomMediaTransportControls()
        {
            this.DefaultStyleKey = typeof(CustomMediaTransportControls);
        }
    
        protected override void OnApplyTemplate()
        {
            Button PreviousTrackButton = GetTemplateChild("PreviousTrackButton") as Button;
            PreviousTrackButton.Click += PreviousTrackButton_Click;
    
    
            base.OnApplyTemplate();
        }
    
        private void PreviousTrackButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
       
    }
