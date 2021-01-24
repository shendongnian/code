    public void ConfigureServices(IServiceCollection services)
    {
    string theEncryptedOne =_configuration.GetConnectionString("MyConnectionString");
    string decrypted =//Do something with the encrypted string. 
    //Pass it when done.
    services.AddDbContext<MyDbContext>(option=>option.UseSqlServer(decryptedString));
    }
   
