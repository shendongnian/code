    public abstract class OouiMvcProgram<T> : Controller where T : class {
        private string MainRoute => "{controller=" + typeof(T).Name + "}/{action=StartUp}/{id?}";
        private string ErrorRoute => $"/{typeof(T).Name}/Error";
        private static XamarinOouiApplication _xamarinApplication = null;
        /// <summary>
        /// The main path to display
        /// </summary>
        protected abstract string MainPageName { get; }
        /// <summary>
        /// Title of the window
        /// </summary>
        protected abstract string Title { get; }
        private static XamarinOouiService Navigation => _xamarinApplication.Service;
        /// <summary>
        /// Let's start the xamarin application
        /// </summary>
        /// <param name="xamarinApplication">Xamarin application</param>
        /// <param name="args"></param>
        public static void StartApplication(XamarinOouiApplication xamarinApplication, string[] args)
        {
            _xamarinApplication = xamarinApplication;
            MessagingCenter.Subscribe<Page, AlertArguments>
                (_xamarinApplication, Page.AlertSignalName, PatchDisplayAlert);
            
            WebHost.CreateDefaultBuilder(args)
               .UseStartup<T>()
               .Build()
               .Run();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">Calling page</param>
        /// <param name="arguments"></param>
        private static void PatchDisplayAlert(Page sender, AlertArguments arguments)
        {
            //DisplayAlert on z-index
            var element = Navigation.CurrentPage.GetOouiElement();
            if (element.GetAttribute("style") == null)
                element.SetAttribute("style", "{z-index:9999;}");
        }
        /// <summary>
        /// This method gets called by the runtime. 
        /// Use this method to add services to the container.
        /// For more information on how to configure your application, 
        /// visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// </summary>
        /// <param name="services"></param>
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }
        /// <summary>
        /// This method gets called by the runtime. 
        /// Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(ErrorRoute);
            }
            app.UseOoui();
            app.UseMvc(routes => routes.MapRoute("default", MainRoute));
        }
        public IActionResult StartUp()
        {
            Navigation.Start(MainPageName);
            var element = Navigation.MainPage.GetOouiElement();
            Navigation.CurrentViewModel?.OnOouiServiceEnabled();
            
            return new ElementResult(element, Title);
        }        
        public IActionResult Error()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            return new ElementResult(GetErrorPage(exceptionFeature).GetOouiElement(), Title);
        }
        /// <summary>
        /// Get the details of the exception that occurred
        /// https://scottsauber.com/2017/04/03/adding-global-error-handling-and-logging-in-asp-net-core/
        /// </summary>
        /// <param name="exceptionFeature"></param>
        /// <returns></returns>
        protected virtual ContentPage GetErrorPage(IExceptionHandlerPathFeature exceptionFeature)
        {
            var errorPage = new ContentPage();
            if (exceptionFeature != null)
            {
                // Get which route the exception occurred at
                string routeWhereExceptionOccurred = exceptionFeature.Path;
                // Get the exception that occurred
                Exception exceptionThatOccurred = exceptionFeature.Error;
                // TODO: Do something with the exception
                // Log it with Serilog?
                // Send an e-mail, text, fax, or carrier pidgeon?  Maybe all of the above?
                // Whatever you do, be careful to catch any exceptions, otherwise you'll end up with a blank page and throwing a 500
                errorPage.Content = new Xamarin.Forms.Label()
                {
                    Text = routeWhereExceptionOccurred + "\n" +
                           exceptionThatOccurred.Message
                };
            }
            return errorPage;
        }                
        public UITarget FindByName(string name)
        {
            var target = Navigation.CurrentPage.GetEventTarget(name);
            return new UITarget(
                add:
                (eventType, handler) => target.AddEventListener(eventType, 
                (element, args) => handler.Invoke(element, args)),
                
                remove:
                (eventType, handler) => target.RemoveEventListener(eventType, 
                (element, args) => handler.Invoke(element, args)));
        }
    }
