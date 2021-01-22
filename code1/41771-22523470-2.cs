    class ProxyObject : MarshalByRefObject
    {
        private Type _type;
        private Object _object;
    
        public void InstantiateObject(string AssemblyPath, string typeName, object[] args)
        {
            assembly = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory + AssemblyPath); //LoadFrom loads dependent DLLs (assuming they are in the app domain's base directory
            _type = assembly.GetType(typeName);
            _object = Activator.CreateInstance(_type, args); ;
        }
    
        public void InvokeMethod(string methodName, object[] args)
        {
            var methodinfo = _type.GetMethod(methodName);
            methodinfo.Invoke(_object, args);
        }
    }
    
    static void Main(string[] args)
    {
        AppDomainSetup setup = new AppDomainSetup();
        setup.ApplicationBase = @"SomePathWithDLLs";
        AppDomain domain = AppDomain.CreateDomain("MyDomain", null, setup);
        ProxyObject proxyObject = (ProxyObject)domain.CreateInstanceFromAndUnwrap(typeof(ProxyObject).Assembly.Location,"ProxyObject");
        proxyObject.InstantiateObject("SomeDLL","SomeType", new object[] { "someArgs});
        proxyObject.InvokeMethod("foo",new object[] { "bar"});
    }
