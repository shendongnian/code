    public class UpdateRandomNumber
    {
        private bool _continue = true;
        private IHubContext<TestHub> testHub;
        private Task randomNumberTask;
        public UpdateRandomNumber(IHubContext<TestHub> testHub)
        {
            this.testHub=testHub;
            randomNumberTask = new Task(() => RandomNumberLoop(),
                TaskCreationOptions.LongRunning);
            randomNumberTask.Start();
        }
        private async void RandomNumberLoop()
        {
            Random r = new Random();
            while (_continue)
            {
                Thread.Sleep(3000);
                int number = r.Next(0, 100);
                Console.WriteLine("The random number is now " + number);
                // Send new random number to connected subscribers here
                 await testHub.Clients.All.SendAsync($"ReceiveRandomNumber", number);
            }
        }
        public void Stop()
        {
            _continue = false;
        }
    }
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSingleton(provider =>
            {
                var hubContext = provider.GetService<IHubContext<TestHub>>();
                var updateRandomNumber = new UpdateRandomNumber(hubContext);
                return updateRandomNumber;
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var updateRandonNumber = app.ApplicationServices.GetService<UpdateRandomNumber>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            app.UseSignalR(routes =>
            {
                routes.MapHub<TestHub>("/testHub");
            });
        }
    }
