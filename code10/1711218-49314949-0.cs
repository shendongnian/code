        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDefaultFiles(new DefaultFilesOptions 
            {
                RequestPath = "/m1",
                FileProvider = new PhysicalFileProvider(@"C:\temp\m1")
            });
            app.UseDefaultFiles(new DefaultFilesOptions 
            {
                RequestPath = "/m2",
                FileProvider = new PhysicalFileProvider(@"C:\temp\m2")
            });               
            app.UseStaticFiles(new StaticFileOptions 
            {
                RequestPath = "/m1",
                FileProvider = new PhysicalFileProvider(@"C:\temp\m1")
            });
            app.UseStaticFiles(new StaticFileOptions 
            {
                RequestPath = "/m2",
                FileProvider = new PhysicalFileProvider(@"C:\temp\m2")
            });            
        }
