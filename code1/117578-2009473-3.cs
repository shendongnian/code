        public interface IRuntime
        {
            bool Run(RuntimesetupInfo setupInfo);
        }
        // The runtime class derives from MarshalByRefObject, so that a proxy can be returned
        // across an AppDomain boundary.
        public class Runtime : MarshalByRefObject, IRuntime
        {
            public bool Run(RuntimeSetupInfo setupInfo)
            {
                // your code here
            }
        }
        // Sample code follows here to create the appdomain, set startup params
        // for the appdomain, create an object in it, and execute a method
        try
        {
            // Construct and initialize settings for a second AppDomain.
            AppDomainSetup domainSetup = new AppDomainSetup()
            {
                ApplicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                ConfigurationFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile,
                ApplicationName = AppDomain.CurrentDomain.SetupInformation.ApplicationName,
                LoaderOptimization = LoaderOptimization.MultiDomainHost
            };
            // Create the child AppDomain used for the service tool at runtime.
            childDomain = AppDomain.CreateDomain(
                "Your Child AppDomain", null, domainSetup);
            // Create an instance of the runtime in the second AppDomain. 
            // A proxy to the object is returned.
            IRuntime runtime = (IRuntime)childDomain.CreateInstanceAndUnwrap(
                typeof(Runtime).Assembly.FullName, typeof(Runtime).FullName);
            // start the runtime.  call will marshal into the child runtime appdomain
            return runtime.Run(setupInfo);
        }
        finally
        {
            // runtime has exited, finish off by unloading the runtime appdomain
            if(childDomain != null) AppDomain.Unload(childDomain);
        }
