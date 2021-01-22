    Fluently.Configure()
				.Database(MsSqlConfiguration.MsSql2008
					.ConnectionString(...)
					.AdoNetBatchSize(500))
				.Mappings(m => m.FluentMappings
					.Conventions.Setup(x =>	x.Add(AutoImport.Never()))
					.AddFromAssembly(...)
					.AddFromAssembly(...)
					.AddFromAssembly(...)
					.AddFromAssembly(...))
				;
