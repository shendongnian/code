    public partial class MainForm : Form
    {
        private WebClient _client = new WebClient();
        public MainForm()
        {
            InitializeComponents();
        }
        private async void ButtonClickHandler(object sender, EventArgs e)
        {
            // after 'await' keyword, execution will be returned from this method immediately
            // meanwhile, actual acquiring of 'stream' is running in a background thread
            using (var stream = await _client.OpenReadTaskAsync(@"https://www.google.com/"))
            {
                // after 300ms, this code will be continued in UI thread
                // result will be automaticly unpacked to 'stream' variable
                
                // some other code
            }
        }
    }
