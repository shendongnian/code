	services.AddSingleton(provider => MassTransit.Bus.Factory.CreateUsingRabbitMq(cfg =>
	{
		var host = cfg.Host("xyz", "/", hst =>
		{
			hst.Username("user");
			hst.Password("pass");
		});
		
		var mappingTypes = new Type[] { typeof(Class1), typeof(Class2), ... etc };
		foreach (var mappingType in mappingTypes)
		{
            // I did mappingType.Name for simplicity, but you could get the mappingType's index in the collection and use that as well if you need this to be a number.
			cfg.ReceiveEndpoint(host, "some_endp_" + mappingType.Name, e =>
			{
				e.LoadFrom(provider);
                // See note at the top of answer.
				EndpointConvention.Map(mappingType, e.InputAddress);
			});
		}
	}));
