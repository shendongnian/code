    public static class MyDataExtensions {
        public static IServiceCollection AddMyData(this IServiceCollection services) {
            //...
            services.AddDbContext<MyContext>(options => options.UseSqlServer(connectionString));
            //...
        }
    }
