    string connectionString = string.Format(@"Data Source={0}", Path.Combine(this.ConfigFolder, ConfigDb));
    string providerName = @"System.Data.SQLite";
    var provider = ProviderFactory.GetProvider(connectionString, providerName);
    _configRepo = new SimpleRepository(provider, SimpleRepositoryOptions.RunMigrations);
 
