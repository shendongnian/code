        public class Startup
        {
            //rest code
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                app.Use((context,next) =>
                {
                    var url = context.Request.GetDisplayUrl();
                    return next.Invoke();
                });
                //rest code
            }
        }
