    public class InjectAttribute : Attribute
    {
    }
    public class TestClass
    {
        [Inject]
        private SomeDependency sd { get; set; }
        public TestClass()
        {
            Console.WriteLine("ctor");
            Console.WriteLine(sd);
        }
    }
    public class SomeDependency
    {
    }
    class Program
    {
        static void Main(string[] args)
        {
            object tc = FormatterServices.GetUninitializedObject(typeof(TestClass));
            // Get all properties with inject tag
            List<PropertyInfo> pi = typeof(TestClass)
                .GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)
                .Where(info => info.GetCustomAttributes(typeof(InjectAttribute), false).Length > 0).ToList();
            // We now happen to know there's only one dependency so we take a shortcut just for the sake of this example and just set value to it without inspecting it
            pi[0].SetValue(tc, new SomeDependency(), null);
            // Find the right constructor and Invoke it. 
            ConstructorInfo ci = typeof(TestClass).GetConstructors()[0];
            ci.Invoke(tc, null);
        }
    }
