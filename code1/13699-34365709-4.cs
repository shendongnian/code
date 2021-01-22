    public static class CopyFactory
    { 
        static readonly Dictionary<Type, PropertyInfo[]> ProperyList = new Dictionary<Type, PropertyInfo[]>();
        public static T CreateCopyReflection<T>(T source) where T : new()
        {
            var copyInstance = new T();
            var sourceType = typeof(T);
            PropertyInfo[] propList;
            if (ProperyList.ContainsKey(sourceType))
                propList = ProperyList[sourceType];
            else
            {
                propList = sourceType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                ProperyList.Add(sourceType, propList);
            }
            foreach (var prop in propList)
            {
                var value = prop.GetValue(source, null);   
                prop.SetValue(copyInstance, value, null);
            }
            return copyInstance;
        }
