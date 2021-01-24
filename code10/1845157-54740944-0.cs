            
    public void ConfigureServices(IServiceCollection services){
       services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
       ConfigureAuth(services);
       
      string machineKey = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
            <machineKey decryption=""Auto"" decryptionKey =""DEC_KEY"" validation=""HMACSHA256"" validationKey=""VAL_KEY"" />";
            var machineKeyConfig = new XmlMachineKeyConfig(machineKey);
            MachineKeyDataProtectionOptions machinekeyOptions = new MachineKeyDataProtectionOptions();
            machinekeyOptions.MachineKey = new MachineKey(machineKeyConfig);
            MachineKeyDataProtectionProvider machineKeyDataProtectionProvider = new MachineKeyDataProtectionProvider(machinekeyOptions);
            MachineKeyDataProtector machineKeyDataProtector = new MachineKeyDataProtector(machinekeyOptions.MachineKey);
       
       //purposes from owin middleware
       IDataProtector dataProtector = 
       machineKeyDataProtector.CreateProtector("Microsoft.Owin.Security.OAuth",
                   "Access_Token", "v1"); 
       services.AddAuthentication(options =>
       {
           options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
       })
       .AddOAuthValidation(option=> {
                option.AccessTokenFormat = new OwinTicketDataFormat(new OwinTicketSerializer(), dataProtector); })
