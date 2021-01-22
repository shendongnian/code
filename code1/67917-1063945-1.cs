    private void SetSubsonicProviderManually(string ConnectionString)  
    {
    //clear the providers and reset  
    DataService.Provider = new SqlDataProvider();  
    DataService.Providers = new DataProviderCollection();  
  
    //instance a section - we'll set this manually for the DataService  
    SubSonicSection section = new SubSonicSection();  
    section.DefaultProvider = __SubsonicProviderName__;  
  
    //set the properties
    DataProvider provider = DataService.Provider;  
    NameValueCollection config = new NameValueCollection();  
  
    //need to add this for now  
    config.Add("connectionStringName", __ConnectionString__);  
    //initialize the provider  
    provider.Initialize(__SubsonicProviderName__, config);  
  
    provider.DefaultConnectionString = ConnectionString;  
  
    DataService.Providers.Add(provider);  
  
    }  
