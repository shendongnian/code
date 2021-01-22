    public static class SingletonHelper {
                public static void CleanDALFactory() 
                {
                        typeof(DalFactory)
                            .GetField("_instance",BindingFlags.Static | BindingFlags.NonPublic)
                            .SetValue(null, null);
                }
    }
