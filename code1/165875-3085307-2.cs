    public static class ManagerFacade
    {
        private static readonly Dictionary<Type, IManager> managerInstances 
          = new Dictionary<Type, IManager>()
        {
            {typeof(XManager), XManager.Instance},
            {typeof(YManager), YManager.Instance}
        };
        private static IManager GetManager<T>() where T: IManager
        {
            return managerInstances[typeof(T)];
        }
        public static object GetObject<T>(int i) where T: IManager
        {
            return GetManager<T>().GetObject(i);
        }
    }
