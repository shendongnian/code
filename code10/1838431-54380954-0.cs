     public void Configure(IApplicationBuilder app, IHostingEnvironment env)
     {          // When not running locally
                if (!env.IsDevelopment())
                {
    				// Get the HttpClient object
    				var httpClient = app.ApplicationServices.GetRequiredService<HttpClient>();
                    // Alter its BaseAddress property value
    				httpClient.BaseAddress = new Uri("https://blazorapi.azurewebsites.net");
                   
                }
                // When running locally let the HttpClient use its BaseAddress default property 
    			// value; that is 'https://localhost			
    			
                app.AddComponent<App>("app");
     }
