    public partial class JobsPage : ContentPage {
        public readonly IApi client;
        public JobsPage () {
            InitializeComponent ();
            //resolving client
            client = DependencyService.Get<IApi>();
            //subscribing to event 
            loadingData += onLoadingData;
            //raising event
            loadingData(this, EventArgs.Empty);
        }
        private async Task SetItemSource() {
            JobListing.ItemsSource = await client.GetJobs();
            //...
        }
        private event EventHandler loadingData = delegate { };
        private async void onLoadingData(object sender, Eventargs args) {
            JobListing.ItemsSource =   await client.GetJobs();
        }
    }
