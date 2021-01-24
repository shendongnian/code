        public void ConfigureServices(IServiceCollection services)
        {
            var coonectionString = "Data Source=localhost\\MSSQLSERVER01;Initial Catalog=AppDb01;Integrated Security=True";
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(coonectionString, builder => builder.UseRowNumberForPaging()));
        }
