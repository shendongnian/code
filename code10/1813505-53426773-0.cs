        public static IServiceCollection ConfigureSqlCacheFromCommand(this IServiceCollection services)
        {
            var options = services.BuildServiceProvider().GetRequiredService<IOptions<SqlServerCacheOptions>>();
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c dotnet sql-cache create \"{options.Value.ConnectionString}\" { options.Value.SchemaName } { options.Value.TableName }",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = false,
                    WindowStyle = ProcessWindowStyle.Normal,
                    RedirectStandardInput = true,
                    RedirectStandardError = true
                }
            };
            process.Start();
            string input = process.StandardError.ReadToEnd();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return services;
        }
