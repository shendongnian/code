c#
public static void InitializeHangFire()
        {
            var sqlStorage = new SqlServerStorage("connectionString");
            var options = new BackgroundJobServerOptions
            {
                ServerName = "Test Server"
            };
            JobStorage.Current = sqlStorage;
        }
