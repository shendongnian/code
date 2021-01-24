    public void ConfigureServices(IServiceCollection services)
    {
            .....other code .....
            var fileName = Path.Combine(env.WebRootPath, "YOUR_FileName" );            
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("Signing Certificate is missing!");
            }
            var cert = new X509Certificate2(fileName, "Your_PassPhrase" );
            services.AddIdentityServer().AddSigningCredential(cert)
            ...other code.....
    }
