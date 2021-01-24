     public class Startup
     {
       public void Configure(IApplicationBuilder app, IHostingEnvironment env)
       {
         if (env.IsDevelopment() || env.IsStaging())
         {
             app.UseDeveloperExceptionPage();
         }
         app.Run(context => { throw new Exception("error"); });
       }
    }
