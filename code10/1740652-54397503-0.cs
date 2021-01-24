     public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseDatabaseErrorPage();
                }
                else
                {
                    //app.UseExceptionHandler("/Home/Error");
    
                    app.UseDeveloperExceptionPage(); // add this to see error
                    app.UseDatabaseErrorPage();    // add this to see  error 
                 
                }
             
               
            }
