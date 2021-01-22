    public class Global : Ninject.Web.NinjectHttpApplication
        {
           
            protected override IKernel CreateKernel()
            {
                return Container;
            }
    
    
            static IKernel Container
            {
                get
                {
                    var standardKernel = new StandardKernel();
                    standardKernel.Bind<ILogger>().To<Logger>();
                    return standardKernel;
                }
    
            }
    
            void Application_Start(object sender, EventArgs e)
            {
                SomeStaticClass.Init(Container);
                SomeStaticClass.Log("Dependency Injection with Statics is totally possible");
    
            }
