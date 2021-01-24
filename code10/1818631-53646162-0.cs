HttpClientFactoryServiceCollectionExtensions.cs
        public static IHttpClientBuilder AddHttpClient<TClient>(this IServiceCollection services)
            where TClient : class
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            AddHttpClient(services);
            var name = TypeNameHelper.GetTypeDisplayName(typeof(TClient), fullName: false);
            var builder = new DefaultHttpClientBuilder(services, name);
            builder.AddTypedClient<TClient>();
            return builder;
        }
HttpClientBuilderExtensions
            public static IHttpClientBuilder AddTypedClient<TClient>(this IHttpClientBuilder builder)
            where TClient : class
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            builder.Services.AddTransient<TClient>(s =>
            {
                var httpClientFactory = s.GetRequiredService<IHttpClientFactory>();
                var httpClient = httpClientFactory.CreateClient(builder.Name);
                var typedClientFactory = s.GetRequiredService<ITypedHttpClientFactory<TClient>>();
                return typedClientFactory.CreateClient(httpClient);
            });
            return builder;
        }
