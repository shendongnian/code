    public PatientModel abc { get; set; }
    public MainPage()
    {
        InitializeComponent();
        Bridge();
        // Using abc
    }
    public async void Bridge()
    {
        abc = new PatientModel();
        abc = await GetPatientData();
    }
    public async Task<PatientModel> GetPatientData()
    {
        PatientModel patient = null;
        try
        {
            Uri weburl = new Uri("myuri");
            HttpClient client = new HttpClient();
            Console.WriteLine("a");
            HttpResponseMessage response = await client.GetAsync(weburl);
            Console.WriteLine("b");
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("in");
                patient = await response.Content.ReadAsAsync<PatientModel>();
                Console.WriteLine("in funciton");
                return patient;
            }
            return patient;
        }catch(Exception ex)
        {
            Console.WriteLine(ex);
            return patient;
        }
    }
