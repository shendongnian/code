		_wjHost = new HostBuilder().ConfigureWebJobs(b =>
		{
			b.AddAzureStorage(x =>
			{
				x.MaxPollingInterval = TimeSpan.FromSeconds(_pollSeconds);
			});
		}).ConfigureServices(s =>
		{
			s.AddSingleton(new StorageAccountProvider(new BlobStorageConfiguration(cfg.DocumentDatabase.BlobStorageServer)));
			s.AddSingleton<INameResolver, Support.BlobNameResolver>(_ => new Support.BlobNameResolver(_env));
			s.Configure<QueuesOptions>(o =>
			{
				o.MaxPollingInterval = TimeSpan.FromSeconds(_pollSeconds);
			});
		}).Build();
