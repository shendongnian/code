    public partial class JobsPage : ContentPage {
        public readonly IApi client;
        public JobsPage () {
            InitializeComponent ();
            client = DependencyService.Get<IApi>();
        }
        private async Task SetItemSource() {
            JobListing.ItemsSource =   await client.GetJobs();
            //...
        }
    }
