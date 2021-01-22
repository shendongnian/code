    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class Person
    {
            public string Name { get; set; }
            public int Age { get; set; }
            public int Weight { get; set; }
            public DateTime FavouriteDay { get; set; }
            public Person PersonInstance { get; set; }
    }
    private static readonly Type stringType = typeof (string);
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
                prop.SetValue(copyInstance,
                    value != null && prop.PropertyType.IsClass && prop.PropertyType != stringType ? CreateCopyReflection((T)value) : value, null);
            }
            return copyInstance;
        }
