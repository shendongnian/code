    public class ApiStartup
    {
        public void ConfigureContainer(IUnityContainer container)
        {
            container.RegisterInstance("This string is displayed if container configured correctly",
                                       "This string is displayed if container configured correctly");
            CustomAuthStorageExtensions.Initialize();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .SetPreflightMaxAge(TimeSpan.FromHours(1));
            }));
           
            IsoDateTimeConverter dateConverter = new IsoDateTimeConverter
            {
                DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fff'Z'"
            };
            services.AddMvc(o =>
            {
                o.ModelBinderProviders.Insert(0, new RowModelBinderProvider());
            }).AddRazorPagesOptions(o =>
            {
            }).AddJsonOptions(o =>
            {
                o.SerializerSettings.Converters.Add(dateConverter);
            });
           
            services.AddSingleton(new MessageProcessorOptions
            {
                ConcurrentMessagesProcesses = 3,
                QueuePath = "earthml-pimeter",
                ListenerConnectionStringKey = "PimetrServiceBus",
            });
            services.AddTransient<IMessageHandler<StorageProviderMessage>, ProviderMessageHandler>();
            services.AddSingleton<IHostedService, ResourceProviderMessageProcessorHostedService>();
        }
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            app.UseCors("ApiCorsPolicy");
        }
    }
    public class PortalStartup
    {
        public void ConfigureContainer(IUnityContainer container)
        {
            container.RegisterInstance("This string is displayed if container configured correctly",
                                       "This string is displayed if container configured correctly");
            CustomAuthStorageExtensions.Initialize();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new CDNHelper());
            IsoDateTimeConverter dateConverter = new IsoDateTimeConverter
            {
                DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fff'Z'"
            };
            services.AddMvc();
            services.AddSignalR(o =>
            {
            }).AddJsonProtocol(j =>
            {
                j.PayloadSerializerSettings.Converters.Add(dateConverter);
            });
        }
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // to do - wire in our HTTP endpoints
                app.Use(async (ctx, next) =>
                {
                    if (Path.GetExtension(ctx.Request.Path) == ".ts" || Path.GetExtension(ctx.Request.Path) == ".tsx")
                    {
                        await ctx.Response.WriteAsync(File.ReadAllText(ctx.Request.Path.Value.Substring(1)));
                    }
                    else
                    {
                        await next();
                    }
                });
            }
            app.UseSignalR(routes =>
            {
                routes.MapHub<DataNotificationHub>("/hubs/notifications");
            });
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
    public class DevStartup
    {
        private PortalStartup PortalStartup = new PortalStartup();
        private ApiStartup ApiStartup = new ApiStartup();
        public void ConfigureContainer(IUnityContainer container)
        {
            ApiStartup.ConfigureContainer(container);
        }
        public void ConfigureServices(IServiceCollection services)
        {
            ApiStartup.ConfigureServices(services);
            PortalStartup.ConfigureServices(services);
        }
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            PortalStartup.Configure(app, env);
        }
    }
