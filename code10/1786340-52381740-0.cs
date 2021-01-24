         public void ConfigureServices(IServiceCollection services)
            {
               //add cors service
                services.AddCors(options => options.AddPolicy("Cors",
                    builder => {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    } ));
    
                services.AddMvc(); // 
//--------------------------------------
  
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
     
  
     public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("Cors");//------>let app use new service
            app.UseMvc();
                               
        }
