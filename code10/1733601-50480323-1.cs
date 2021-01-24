    public abstract class ActionBase
    {
        private static MethodInfo getServiceMI;
        static ActionBase()
        {
            // Find out which assembly implement ServiceLocator.
            var asm = AppDomain.CurrentDomain.GetAssemblies().First(x => x.GetTypes().Any(y => y.Name == "ServiceLocator"));
            // Get MethodInfo of ServiceLocator.GetService.
            getServiceMI = asm.GetType("ServiceLocator").GetMethod("GetService", BindingFlags.Public | BindingFlags.Static);
        }
        protected static object GetService(string name)
        {
            return getServiceMI.Invoke(null, new object[] { name });
        }
        // And your original staff.
    }
    public class ActionSample : ActionBase
    {
        IDependency1 d1 = GetService("name1");
        ...
        IDependencyN dN = GetService("nameN");
        public override ResultBase ExecuteAction()
        {
            d1.DoSomething();
            ...
            dN.DoSomething();
        }
    }
