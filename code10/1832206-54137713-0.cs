    public class TestClassGeneric<T> where T : new()
    {
        public void Generic_FilterValue_TestMethod()
        {
            var filter = new T();
            // ManipulateData(filter);
        }
    }
    
    public class TestClassConstructorArg
    {
        private readonly Type type;
    
        public TestClassConstructorArg(Type type)
        {
            this.type = type;
        }
    
        public void Generic_FilterValue_TestMethod()
        {
            var filter = Activator.CreateInstance(type);
            // var filter = Activator.CreateInstance(type, BindingFlags.CreateInstance, arguments...);
            // ManipulateData(filter);
        }
    }
