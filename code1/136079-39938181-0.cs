    public static class MyClientClass
    {
        private static MarshalByRefObject remoteClass;
        static MyClientClass()
        {
            CreateRemoteInstance();
        }
        // ...
        public static void DoStuff()
        {
            // Before doing stuff, check if the remote object is still reachable
            try {
                remoteClass.GetLifetimeService();
            }
            catch(RemotingException) {
                CreateRemoteInstance(); // Re-create remote instance
            }
            // Now we are sure the remote class is reachable
            // Do actual stuff ...
        }
        private static void CreateRemoteInstance()
        {
            remoteClass = (MarshalByRefObject)AppDomain.CurrentAppDomain.CreateInstanceFromAndUnwrap(remoteClassPath, typeof(MarshalByRefObject).FullName);
        }
    }
