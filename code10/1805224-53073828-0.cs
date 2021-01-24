    public class MvcApplication : SenseNet.Portal.SenseNetGlobal
    {
        protected override void Application_Start(object sender, EventArgs e, HttpApplication application)
        {
            ...
        }
    
        protected override void BuildRepository(IRepositoryBuilder repositoryBuilder)
        {
            repositoryBuilder.UseLogger(new SnFileSystemEventLogger());
        }
    }
