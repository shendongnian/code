    private int selectedLocation;
     public SummaryDetail(CpDetails cp)
            {
                InitializeComponent();
                
                GetLocations();
                BindingContext = cp;                
                selectedLocation = cp.LocationId;    
    }
    public async void GetLocations()
            {
                var loci = new List<Locations>();
                var client = new HttpClient();   
    
                var json = await client.GetStringAsync("this is link");
                loci = JsonConvert.DeserializeObject<List<Locations>>(json);
                foreach (var item in loci)
                {
                    pklocation.Items.Add(item.Name);
                    if (item.Id == selectedLoacion)
                        pklocation.SelectedIndex = item.Id;
                }
               
            }
