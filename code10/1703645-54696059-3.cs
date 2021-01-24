			services.AddMySwagger(
				new ApiVersion(1, 0),
				__description => new Info { Title = $"API v{__description.ApiVersion}", Version = __description.ApiVersion.ToString() },
				Configuration.GetValue<string>("Authentication:Authority"),
				new Dictionary<string, string> { { Configuration.GetValue<string>("Authentication:Scope"), "Partnership API" } }
			);
