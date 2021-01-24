     public MainPage()
        {
            InitializeComponent();
            GetStat();
        }
        private async void GetStat()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("http://ropenrom2-001-site1.etempurl.com/Restserver/index.php/customer/view_table_orders");
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(ms);
            selectOrd.ItemsSource = data.table;
        }
