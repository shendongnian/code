        protected static class DoSomethingServer<T1> where T1 : class
        {
            //Define your allowed types here
            private static List<Type> AllowedTypes = new List<Type> {
                typeof(IInterface1),
                typeof(IInterface2)
            };
            public static MethodInvoker DoSomething()
            {
                //Perform type check
                if (AllowedTypes.Contains(typeof(T1)))
                {
                    return DoSomethingImplementation;
                }
                else
                {
                    throw new ApplicationException("Wrong Type");
                }
            }
            private static void DoSomethingImplementation()
            {
                //Actual DoSomething work here
                //This is guaranteed to only be called if <T> is in the allowed type list
            }
        }
