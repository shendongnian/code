    public class LibCore
    {
        public static object GetRawConstantValue(Type target, string filedName)
        {
            var filed = target.GetField(filedName);
            var value = filed.GetRawConstantValue();
            return value;
        }
    }
