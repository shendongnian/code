    public static class ServiceLocator
    {
        private static Dictionary<string, Type> container = new Dictionary<string, Type>();
       
        public static void RegisterService(string name, Type implType)
        {
            container.Add(name, implType);
        }
        public static objcet GetService(string name)
        {
            return Actinator.CreateInstance(container[name]);
        }
    }
