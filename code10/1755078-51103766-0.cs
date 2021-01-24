    class Mapper
    {
        public static object Map<TMModel>(TMModel q) where TMModel : class
        {
            MethodInfo methodInfo = typeof(Mapper).GetMethod("Map", new Type[] { q.GetType() });
            if (methodInfo != null)
                return methodInfo.Invoke(null, new object[] { q });
            return null;
        }
        public static GroupDevides Map(MM.GroupDevides e)
        {
            //map to GroupDevides
        }
    }
