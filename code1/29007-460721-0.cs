       public class GlobalApplication : System.Web.HttpApplication, IContainerAccessor
       {
         private static readonly WindsorContainer _container = new WindsorContainer(new XmlInterpreter(new ConfigResource("castle")));
         public IWindsorContainer Container
         {
             get { return _container; }
         }
       }
