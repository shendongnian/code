    public static class Factory
    {
        private static List<FactoryObject> knownObjects = new List<FactoryObject>();
        public static void RegisterType(FactoryObject obj)
        {
            knownObjects.Add(obj);
        }
        public static T Instantiate<T>() where T : FactoryObject
        {
            var knownObject = knownObjects.Where(x => x.GetType() == typeof(T));
            return (T)knownObject.Instantiate();
        }
    }
