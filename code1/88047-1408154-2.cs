    public class Example {
        public void CallingTest()
        {
            MethodInfo method = GetMethod<Program>(x => x.Test<object>());
            MethodInfo genericMethod = method.MakeGenericMethod(typeof (string));
            genericMethod.Invoke(new Program(), null);
        }
        public static MethodInfo GetMethod<T>(Expression<Action<T>> expr)
        {
            return ((MethodCallExpression) expr.Body)
                .Method
                .GetGenericMethodDefinition();
        }
        public void Test<T>()
        {
            Console.WriteLine(typeof (T).Name);
        }
    }
