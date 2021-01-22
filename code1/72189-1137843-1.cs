    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFile(@"C:\dyn.dll");
            Type type = assembly.GetType("TestRunner");
            var obj = (TestRunner)Activator.CreateInstance(type);
            obj.Run();
        }
    }
