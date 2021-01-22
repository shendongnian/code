    delegate void OpenInstanceDelegate(A instance, int a);
    class A
    {
        public void Method(int a) {}
        static void Main(string[] args)
        {
            A a = null;
            MethodInfo method = typeof(A).GetMethod("Method");
            OpenInstanceDelegate action = (OpenInstanceDelegate)Delegate.CreateDelegate(typeof(OpenInstanceDelegate), a, method);
            PossiblyExecuteDelegate(action);
        }
    }
