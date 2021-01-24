    public partial class MainForm : Form
    {
        private WebClient _client = new WebClient();
        public MainForm()
        {
            InitializeComponents();
            _client.OpenReadCompleted += OpenReadCompletedHandler;
        }
        private void ButtonClickHandler(object sender, EventArgs e)
        {
            _client.OpenReadAsync(@"https://www.google.com/");
        }
        private void OpenReadCompletedHandler(object sender, OpenReadCompletedEventArgs e)
        {
            // this event will be raiesed 300ms after 'Button' click
            var stream = e.Result; // <- here is your stream
            // some other code
        }
    }
