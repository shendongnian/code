    public static class SpringApplicationContext
    {
        private static IApplicationContext Context { get; set; }
        /// <summary> 
        /// Returns a boolean value if the current application context contains an named object. 
        /// </summary> 
        /// <param name="objectName">Accepts the name of the object to check.</param> 
        public static bool Contains(string objectName)
        {
            SpringApplicationContext.EnsureContext();
            return SpringApplicationContext.Context.ContainsObject(objectName);
        }
        /// <summary> 
        /// Return a instance of an object in the context by the specified name. 
        /// </summary> 
        /// <param name="objectName">Accepts a string object name.</param> 
        public static object Resolve(string objectName)
        {
            SpringApplicationContext.EnsureContext();
            return SpringApplicationContext.Context.GetObject(objectName);
        }
        /// <summary> 
        /// Return a instance of an object in the context by the specified name and type. 
        /// </summary> 
        /// <typeparam name="T">Accepts the type of the object to resolve.</typeparam> 
        /// <param name="objectName">Accepts a string object name.</param> 
        public static T Resolve<T>(string objectName)
        {
            return (T)SpringApplicationContext.Resolve(objectName);
        }
        private static void EnsureContext()
        {
            if (SpringApplicationContext.Context == null)
            {
                SpringApplicationContext.Context = ContextRegistry.GetContext();
            }
        }
    } 
