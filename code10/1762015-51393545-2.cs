    public class CustomObject<T> where T : class {}
    public interface IInterface { }
    public static class CustomObjectConverter
    {
        public static CustomObject<T1> ConvertTo<T1, T2>(CustomObject<T2> other)
            where T1 : class
            where T2 : class
        {
            return new CustomObject<T1>();
        }
    }
    public CustomObject<T> MethodA<T>(T arg1) where T : class
    {
        if (arg1 is IInterface inf)
        {
            var b = MethodB(inf);
            return CustomObjectConverter.ConvertTo<T,IInterface>(b);
        }
        return null;
    }
    public CustomObject<T> MethodB<T>(T arg2) where T : class, IInterface
    {
        return new CustomObject<T>();
    }
