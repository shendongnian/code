`public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc().AddRazorPagesOptions(options =>
    {
        //Registering 'Page','route-name'
        options.Conventions.AddPageRoute("/Account/Login", "");
    });
}
`
* Remember to remove any route name on "/Account/Login" Action declaration
