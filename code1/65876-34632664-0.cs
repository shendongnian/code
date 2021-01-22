    #if (NET10 || NET11 || NET20 || NET30 || NET35)
    public static class MimeExtensionHelper
    {
        static object locker = new object();
        static MethodInfo getMimeMappingMethodInfo;
        static MimeExtensionHelper()
        {
            Type mimeMappingType = Assembly.GetAssembly(typeof(HttpRuntime)).GetType("System.Web.MimeMapping");
            if (mimeMappingType == null)
                throw new SystemException("Couldnt find MimeMapping type");
            ConstructorInfo constructorInfo = mimeMappingType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null);
            if (constructorInfo == null)
                throw new SystemException("Couldnt find default constructor for MimeMapping");
            mimeMapping = constructorInfo.Invoke(null);
            if (mimeMapping == null)
                throw new SystemException("Couldnt find MimeMapping");
            getMimeMappingMethodInfo = mimeMappingType.GetMethod("GetMimeMapping", BindingFlags.Static | BindingFlags.NonPublic);
            if (getMimeMappingMethodInfo == null)
                throw new SystemException("Couldnt find GetMimeMapping method");
            if (getMimeMappingMethodInfo.ReturnType != typeof(string))
                throw new SystemException("GetMimeMapping method has invalid return type");
            if (getMimeMappingMethodInfo.GetParameters().Length != 1 && getMimeMappingMethodInfo.GetParameters()[0].ParameterType != typeof(string))
                throw new SystemException("GetMimeMapping method has invalid parameters");
        }
        public static string GetMimeType(string fileName)
        {
            lock (locker)
            {
                return (string)getMimeMappingMethodInfo.Invoke(null, new object[] { fileName });
            }
        }
    }
    #elif NET40
    public static class MimeExtensionHelper
    {
        static object locker = new object();
        static MethodInfo getMimeMappingMethodInfo;
        static MimeExtensionHelper()
        {
            Type mimeMappingType = Assembly.GetAssembly(typeof(HttpRuntime)).GetType("System.Web.MimeMapping");
            if (mimeMappingType == null)
                throw new SystemException("Couldnt find MimeMapping type");           
 
            getMimeMappingMethodInfo = mimeMappingType.GetMethod("GetMimeMapping", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            if (getMimeMappingMethodInfo == null)
                throw new SystemException("Couldnt find GetMimeMapping method");
            if (getMimeMappingMethodInfo.ReturnType != typeof(string))
                throw new SystemException("GetMimeMapping method has invalid return type");
            if (getMimeMappingMethodInfo.GetParameters().Length != 1 && getMimeMappingMethodInfo.GetParameters()[0].ParameterType != typeof(string))
                throw new SystemException("GetMimeMapping method has invalid parameters");
        }
        public static string GetMimeType(string fileName)
        {
            lock (locker)
            {
                return (string)getMimeMappingMethodInfo.Invoke(null, new object[] { fileName });
            }
        }
    }
    #else // .NET 4.5 or later
    public static class MimeExtensionHelper
    {
        public static string GetMimeType(string fileName)
        {
            return MimeMapping.GetMimeMapping(fileName);
        }
    }
    #endif
