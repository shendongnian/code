    public class MyWrapper
    {
        object _wrappedClass;
        public MyWrapper(object obj)
        {
            _wrappedClass = obj;
        }
        //...
        public void API2()
        {
            MethodInfo api2 = _wrappedClass.GetType().GetMethod("API2");
            api2.Invoke(_wrappedClass);
        }
        //...
    }
