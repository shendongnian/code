        public void ConfigureServices(IServiceCollection services)
        {
            ...
            services.AddSingleton<ITableStorageAccount, TableStorageAccount>();
        }
