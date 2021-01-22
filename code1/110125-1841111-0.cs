    public class MvcApplication : TurbineApplication
    {
        static MvcApplication()
        {
            //ServiceLocatorManager.SetLocatorProvider(() => new UnityServiceLocator());           
            ServiceLocatorManager.SetLocatorProvider(() => new NinjectServiceLocator()); 
        }
    }
