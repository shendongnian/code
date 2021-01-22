    public class Example {
        public void CallingTest()
        {
            MethodInfo method = typeof (Example).GetMethod("Test");
            MethodInfo genericMethod = method.MakeGenericMethod(typeof (string));
            genericMethod.Invoke(this, null);
        }
        public void Test<T>()
        {
            Console.WriteLine(typeof (T).Name);
        }
    }
