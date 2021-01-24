    	public static class ServiceCollectionExtension
	{
		private static string XmlCommentsFilePath
		{
			get
			{
				var basePath = PlatformServices.Default.Application.ApplicationBasePath;
				var fileName = Assembly.GetEntryAssembly().GetName().Name + ".xml";
				return Path.Combine(basePath, fileName);
			}
		}
		public static void AddMySwagger(
			this IServiceCollection services,
			ApiVersion defaultApiVersion,
			Func<ApiVersionDescription, Info> info,
			string authority = null,
			Dictionary<string, string> scopes = null)
		{
			services.AddMvcCore().AddVersionedApiExplorer(o => o.GroupNameFormat = "'v'VVV");
			services.AddApiVersioning(o =>
			{
				o.ReportApiVersions = true;
				o.AssumeDefaultVersionWhenUnspecified = true;
				o.DefaultApiVersion = defaultApiVersion;
			});
			services.AddSwaggerGen(
				options =>
				{
					var provider = services.BuildServiceProvider()
						.GetRequiredService<IApiVersionDescriptionProvider>();
					foreach (var description in provider.ApiVersionDescriptions)
					{
						if (!description.IsDeprecated)
							options.SwaggerDoc(description.GroupName, info(description));
					}
					options.OperationFilter<DefaultValues>();
					options.IncludeXmlComments(XmlCommentsFilePath);
					if (!string.IsNullOrEmpty(authority))
					{
						options.AddSecurityDefinition("jwt", new ApiKeyScheme()
						{
							Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
							Name = "Authorization",
							In = "header",
							Type = "apiKey"
						});
						//options.AddSecurityDefinition("oauth2", new OAuth2Scheme
						//{
						//	Flow = "implicit",
						//	AuthorizationUrl = $"{authority}/connect/authorize",
						//	Scopes = scopes ?? new Dictionary<string, string>()
						//});
						options.OperationFilter<AuthorizeCheckOperationFilter>(scopes?.Select(_ => _.Key).ToList() ?? new List<string>());
					}
				});
		}
		class AuthorizeCheckOperationFilter : IOperationFilter
		{
			private readonly IEnumerable<string> _scopes;
			public AuthorizeCheckOperationFilter(IEnumerable<string> scopes)
			{
				_scopes = scopes;
			}
			public void Apply(Operation operation, OperationFilterContext context)
			{
				var hasAuthorize = context.ApiDescription.ControllerAttributes().OfType<AuthorizeAttribute>().Any() ||
								   context.ApiDescription.ActionAttributes().OfType<AuthorizeAttribute>().Any();
				if (hasAuthorize)
				{
					operation.Responses.Add("401", new Response { Description = "Unauthorized" });
					operation.Responses.Add("403", new Response { Description = "Forbidden" });
					operation.Security = new List<IDictionary<string, IEnumerable<string>>> {
					new Dictionary<string, IEnumerable<string>>
					{
						//{"oauth2", _scopes},
						{"jwt", _scopes }
					}
				};
				}
			}
		}
	}
