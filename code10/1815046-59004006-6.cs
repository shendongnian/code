    public static class ApiOrchestration
    {
        public static void Create(IApiOrchestrator orchestrator, IApplicationBuilder app)
        {           
            orchestrator.AddApi("weatherservice", "http://localhost:58262/")
                                .AddRoute("forecast", new RouteInfo { Path = "weatherforecast/forecast", ResponseType = typeof(IEnumerable<WeatherForecast>) })                                
                        .ToOrchestrator()
                        .AddApi("stockservice", "http://localhost:58352/")
                                .AddRoute("stocks", new RouteInfo { Path = "stock", ResponseType = typeof(IEnumerable<StockQuote>) });
        }
    }
* Hook up in Startup.cs
       public void ConfigureServices(IServiceCollection services)
        {
            .
            .
            //Api gateway
            services.AddApiGateway();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Api Gateway", Version = "v1" });
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            .
            .
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Api Gateway");
            });
            //Api gateway
            app.UseApiGateway(orchestrator => ApiOrchestration.Create(orchestrator, app));
            .
            .
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
The Gateway Swagger appears as shown below:
[![Gateway Api][1]][1]
To call the forecast route on the weather service,
you can enter the Api key and Route key into Swagger as below:
[![Api Gateway call][2]][2]
This will hit the weatherforecast/forecast endpoint on the backend Weather API.
### Features
*	You can use your own **HttpClient** to hit the backend Api.
*	You can create your own implementation to hit the backend Api.
  [1]: https://i.stack.imgur.com/IiVdw.png
  [2]: https://i.stack.imgur.com/ETRmQ.png
  [3]: https://i.stack.imgur.com/OFjue.png
