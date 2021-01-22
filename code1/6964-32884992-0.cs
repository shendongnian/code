    public class EnumHelper
    {
        private static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
        public static IEnumerable getListOfEnum(Type type)
        {
            MethodInfo getValuesMethod = typeof(EnumHelper).GetMethod("GetValues").MakeGenericMethod(type);
            return (IEnumerable)getValuesMethod.Invoke(null, null);
        }
    }
