    public class MsDiControllerFactory : DefaultControllerFactory
    {
        private readonly ServiceProvider container;
        public MsDiControllerFactory(ServiceProvider container) => this.container = container;
        protected override IController GetControllerInstance(RequestContext c, Type type) =>
            (IController)this.GetScope().ServiceProvider.GetRequiredService(type);
        
        public override void ReleaseController(IController c) => this.GetScope().Dispose();
        private IServiceScope GetScope() =>
           (IServiceScope)HttpContext.Current.Items["scope"] ??
              (IServiceScope)(HttpContext.Current.Items["scope"] = this.container.CreateScope());
    }
