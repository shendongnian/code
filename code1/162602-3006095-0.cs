    public static class MyDllCalls
    {
        private static object _lockObject = new object();
    
        public static int SomeCall()
        {
            lock (_lockObject)
            {
                return CallSomeFunctionInYourDll();
            }
        }
    }
