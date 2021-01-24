    static HttpClient client = new HttpClient();
    public MainPage() {
        InitializeComponent();
        loadingData += onLoadingData;        
    }
    protected override void OnAppearing() {
        //loadingData -= onLoadingData; //(optional)
        loadingData(this, EventArgs.Empty);
        base.OnAppearing();
    }
    private event EventHandler loadingData = delegate { };
    private async void onLoadingData(object sender, EventArgs args) {
        var model = await GetPatientData();
        this.BindingContext = new PatientViewModel(model);
    }
    public async Task<PatientModel> GetPatientData() {
        PatientModel patient = null;
        try {
            Uri weburl = new Uri("myuri");
            Console.WriteLine("a");
            var response = await client.GetAsync(weburl);
            Console.WriteLine("b");
            if (response.IsSuccessStatusCode) {
                Console.WriteLine("in");
                patient = await response.Content.ReadAsAsync<PatientModel>();
                Console.WriteLine("in funciton");
            }           
        }catch(Exception ex) {
            Console.WriteLine(ex);
        }
        return patient;
    }
