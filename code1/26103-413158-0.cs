    public class Services
    {
        protected static Dictionary<Type, object> services = new Dictionary<Type, object>();
        private Services() 
        {
        }
        static Services()
        {
            // hard coded implementations...
            services.Add(typeof(IMailService), new DefaultMailServiceImplementation());
        }
        public static T Get<T>() where T : class
        {
            Type requestedType = typeof(T);
            return services[requestedType] as T;
        }
    }
