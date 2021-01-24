 lang-cs
public void Configure(IApplicationBuilder app)
{
    app.UseDefaultFiles()
       .UseStaticFiles()
       .UseBotFramework()
       .UseMvc();    
}
