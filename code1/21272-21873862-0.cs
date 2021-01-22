            builder.ConfigureData()
                   .ForDatabaseNamed("LocalSqlServer1")
                     .ThatIs.ASqlDatabase()
                     .WithConnectionString(@"Data Source=PCNAME\SQLEXPRESS;Initial Catalog=ContactDB;Integrated Security=True")
                   .ForDatabaseNamed("LocalSqlServer2")
                     .ThatIs.ASqlDatabase()
                     .WithConnectionString(@"Data Source=PCNAME\SQLEXPRESS;Initial Catalog=MyDB;Integrated Security=True");
            var configSource = new DictionaryConfigurationSource();
            builder.UpdateConfigurationWithReplace(configSource);
