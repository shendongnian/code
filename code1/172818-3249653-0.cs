    public class MvcApplication : TurbineApplication {
        static MvcApplication() {
            // Register the IoC that you want Mvc Turbine to use!
            // Everything else is wired automatically
            // For now, let's use the Unity IoC
            ServiceLocatorManager.SetLocatorProvider(() => new UnityServiceLocator());
        }
        public override void Startup(){
             // Gets called when the application starts up
             // and before all the stuff that Turbine wires up
        }
        public override void Shutdown() {
             // Gets called when the application shuts down
             // and before any cleanup is done by Turbine
        }
    }
