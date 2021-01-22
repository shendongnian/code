    public partial class MainControl : UserControl
    {
        private Button myButtonToKeepAroundAllTheTime;
    
        protected void TriggerButton_Click(object sender, EventArgs e)
        {
            myButtonToKeepAroundAllTheTime = new Button()
            {
                Content = "Click Me",
                Height = 20
            };
        }
    }
