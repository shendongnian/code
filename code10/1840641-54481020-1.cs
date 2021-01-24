    public void Configure(IApplicationBuilder app, IHostingEnvironment env, WhiteBoxDBContext context)
        {
            app.UseCors("AllowOrigin");
            app.UseMvc();
        }
 
