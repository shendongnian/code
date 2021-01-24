    public class MyTestMiddleware : OwinMiddleware
    {
        public MyTestMiddleware(OwinMiddleware next) : base(next) {}
        public override async Task Invoke(IOwinContext context)
        {
            System.Diagnostics.Debug.WriteLine("INVOKED");
            await Next.Invoke(context);
        }
    }
    app.UseOwin(setup => setup(next =>
    {
        var owinAppBuilder = new AppBuilder();
        // set the DefaultApp to be next
        owinAppBuilder.Properties["builder.DefaultApp"] = next;
        // add your middlewares here as Types
        owinAppBuilder.Use(typeof(MyTestMiddleware));
        return owinAppBuilder.Build<Func<IDictionary<string, object>, Task>>();
    }));
