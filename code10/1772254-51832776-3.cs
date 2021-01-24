    [assembly: OwinStartup(typeof(Startup))]
    public class Startup {
        public void Configuration(IAppBuilder app) {
            app.Use((context, next) => {
                Container.CallId = 5;
                return next.Invoke();
            });
        }
    }
