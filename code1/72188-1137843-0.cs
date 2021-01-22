    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFile(@"C:\dyn.dll");
            Type type = assembly.GetType("TestRunner");
            object obj = Activator.CreateInstance(type);
            obj.Run();
        }
    }
