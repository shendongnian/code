    namespace Collections
    {
        public class CSuperAutoPool
        {
            public static CSuperAutoPool ActivateByType(
                Type typeToBeActivated, params object[] activatedArguments)
            {
                //...
                return null;
            }
        }
    }
    
    namespace Organization
    {
        using Collections;
        public class CBaseEntity : CSuperAutoPool
        {
            protected static CBaseEntity Create()
            {
                Type callingType = null;
                //...
                CBaseEntity created = 
                    (CBaseEntity)CSuperAutoPool.ActivateByType(callingType); 
                //...
                return created;
            }
        }
    }
