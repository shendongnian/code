    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class Person
    {
           ...
          Job JobDescription
           ...
    }
    
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class Job
        {...
        }
    private static readonly Type stringType = typeof (string);
    public static class CopyFactory
    { 
        static readonly Dictionary<Type, PropertyInfo[]> ProperyList = new Dictionary<Type, PropertyInfo[]>();
        private static readonly MethodInfo CreateCopyReflectionMethod;
        static CopyFactory()
        {
            CreateCopyReflectionMethod = typeof(CopyFactory).GetMethod("CreateCopyReflection", BindingFlags.Static | BindingFlags.Public);
        }
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
                    value != null && prop.PropertyType.IsClass && prop.PropertyType != stringType ? CreateCopyReflectionMethod.MakeGenericMethod(prop.PropertyType).Invoke(null, new object[] { value }) : value, null);
            }
            return copyInstance;
        }
