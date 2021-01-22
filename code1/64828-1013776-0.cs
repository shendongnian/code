        private Request ExecuteAutoTransition(Type newStatus)
        {
            // No transition needed
            if (newStatus == null)
            {
                return Request;
            }
            // Create an instance of the type
            object o = Activator.CreateInstance(
                newStatus, // type
                new Object[] // constructor parameters
                    {
                        Request,
                        TarsUser,
                        GrantRepository,
                        TrackingRepository
                    });
            // Execute status change
            return (Request) newStatus.InvokeMember(
                                 "Execute", // method
                                 BindingFlags.Public 
                                    | BindingFlags.Instance 
                                    | BindingFlags.InvokeMethod, // binding flags
                                 Type.DefaultBinder, // binder
                                 o, // type
                                 null); // method parameters
        }
