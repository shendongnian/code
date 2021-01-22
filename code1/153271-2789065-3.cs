    public static class MyExtensions
    {
        public static void ShutDown(this IMyInterface obj, ...) { ... }
    }
    // ...then your code might look like:
    object x = null;
    MethodInfo method = typeof(MyExtensions).GetMethod("ShutDown");
    method.Invoke(x as IMyInterface, new object[] { 4 });
