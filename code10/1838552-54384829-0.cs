public void ConfigureServices(IServiceCollection services)
{
    services.AddHangfire(configuration => {
        configuration.UseStorage(
            new MySqlStorage(
                "server=127.0.0.1;uid=root;pwd=root;database={0};Allow User Variables=True",
                new MySqlStorageOptions
                {
                    TablesPrefix = "Hangfire"
                }
            )
        );
    };
}
