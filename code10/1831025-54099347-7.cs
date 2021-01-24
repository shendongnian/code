    using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();
                try
                {
                    logger.LogInformation("Starting settings validation.");
                    services.GetRequiredService<SettingsValidator>();
                    logger.LogInformation("The settings have been validated.");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while validating the settings.");
                }
            }
