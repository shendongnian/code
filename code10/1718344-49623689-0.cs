    public void ConfigureServices(IServiceCollection services)
        {
            services.AddHangfire(x => x.UseSqlServerStorage("server=.\\sqlexpress;initial catalog=hangfire;Integrated Security=true"));
            services.AddMvc();
        }
