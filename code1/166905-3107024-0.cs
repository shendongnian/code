    private static class Invoker
    {
        private static string Method()
        {
            return "beep";
        }
        public static object Invoke()
        {
            Type type = Type.GetType("Bla.Session, FooSessionDll", true);
            MethodInfo methodInfo = type.GetMethod("Execute");
            Type delegateType = methodInfo.GetParameters()[2].ParameterType;
            Delegate delegateInstance = Delegate.CreateDelegate(delegateType, typeof(Invoker).GetMethod("Method"));
            object[] args = new object[] { "foo", "bar", delegateInstance };
            return methodInfo.Invoke(null, args);
        }
    }
