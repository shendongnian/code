         public void Configure(IApplicationBuilder app)
         {
            app.UseDataEngineProviders().AddDataEngine("DB Name", @"Data Source=;Provider=;Initial Catalog=", "table name");
            app.UseStaticFiles();
            app.UseMvc();
         }
