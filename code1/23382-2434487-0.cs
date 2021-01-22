        /// <summary>
        /// Obtain the DataContext providing this entity
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DataContext GetContext(this ISandboxObject obj)
        {
            FieldInfo fEvent = obj.GetType().GetField("PropertyChanging", BindingFlags.NonPublic | BindingFlags.Instance);
            MulticastDelegate dEvent = (MulticastDelegate)fEvent.GetValue(obj);
            Delegate[] onChangingHandlers = dEvent.GetInvocationList();
            
            // Obtain the ChangeTracker
            foreach (Delegate handler in onChangingHandlers)
            {
                if (handler.Target.GetType().Name == "StandardChangeTracker")
                {
                    // Obtain the 'services' private field of the 'tracker'
                    object tracker = handler.Target;
                    object services = tracker.GetType().GetField("services", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(tracker);
                    
                    // Get the Context
                    DataContext context = services.GetType().GetProperty("Context").GetValue(services, null) as DataContext;
                    return context;
                }
            }
            
            // Not found
            throw new Exception("Error reflecting object");
        }
