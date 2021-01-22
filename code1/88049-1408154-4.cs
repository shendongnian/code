    public class Example {
        public void CallingTest()
        {
            MethodInfo method = GetMethod<Example>(x => x.Test<object>());
            MethodInfo genericMethod = method.MakeGenericMethod(typeof (string));
            genericMethod.Invoke(this, null);
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
