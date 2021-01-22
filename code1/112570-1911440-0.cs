    public enum ReflectionTestMethods
    {
        MethodA,
        MethodB,
        MethodC
    }
    public class ReflectionTest
    {
        
        public void Execute(ReflectionTestMethods method)
        {
            MethodInfo methodInfo = GetType().GetMethod(method.ToString()
                , BindingFlags.Instance | BindingFlags.NonPublic);
            if (methodInfo == null) throw new NotImplementedException(method.ToString());
            methodInfo.Invoke(this, null);
        }
        private void MethodA()
        {
            Debug.Print("MethodA");
        }
        private void MethodB()
        {
            Debug.Print("MethodB");
        }
        private void MethodC()
        {
            Debug.Print("MethodC");
        }
    }
