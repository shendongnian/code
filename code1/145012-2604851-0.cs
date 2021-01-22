    public class A<T>
    {
        public static string B(T obj)
        {
            return obj.ToString();
        }
    }
    public class MyClass
    {
        public static void DoExample()
        {
            Console.WriteLine(ExecuteB("Hi"));
            Console.WriteLine(ExecuteB(DateTime.Now));
        }
        public static object ExecuteB(object arg)
        {
            Type arg_type = arg.GetType();
            Type class_type = typeof(MyClass);
            MethodInfo mi = class_type.GetMethod("ExecuteBGeneric", BindingFlags.Static | BindingFlags.Public);
            MethodInfo mi2 = mi.MakeGenericMethod(new Type[] { arg_type });
            return mi2.Invoke(null, new object[] { arg });
        }
        public static object ExecuteBGeneric<T>(T arg)
        {
            return A<T>.B(arg);
        }
