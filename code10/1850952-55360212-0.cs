    ContextAOptionsBuilder.UseSqlServer(Configuration.GetConnectionString("ContextAConnectionString"), builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(30), null);
            });
    ContextAOptionsBuilder.EnableSensitiveDataLogging();
